using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using StayUpdated.DAL;
using StayUpdated.DTO;
using StayUpdated.Interfaces;
using StayUpdated.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StayUpdated.Services {

	public class NewsService : INewsService {

		private StayUpdatedContext db = new StayUpdatedContext();
		private IUserSettingsService userSettingsService;

		HttpClient client = new HttpClient();
		NewsApiClient newsApi;

		public NewsService(IUserSettingsService _userSettingsService) {
			userSettingsService = _userSettingsService;

			// this HttpCLient is used to get all the available sources
			client.BaseAddress = new Uri("https://newsapi.org/v2/");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//move key to config later
			newsApi = new NewsApiClient("a96df9dbc6624717932b21dabce240d5");
		}

		public async Task<ArticlesResult> GetAll(string query) {

			// get user settings, this should be using the current user Id in the future
			UserSettings settings = await userSettingsService.Get();

			ArticlesResult articlesResponse;

			if (query==null) {
				// We get the top headlines according to the user settings
				articlesResponse = await newsApi.GetTopHeadlinesAsync(new TopHeadlinesRequest {
					Sources = settings.SourcesIds.Split(',').ToList(),
					Language = (Languages)Enum.Parse(typeof(Languages), settings.LanguageCd.ToUpper()),
					Page = settings.Page,
					PageSize = settings.PageSize
				});
			} else {
				articlesResponse = await newsApi.GetEverythingAsync(new EverythingRequest {
					Q = query,
					Sources = settings.SourcesIds.Split(',').ToList(),
					SortBy = settings.SortBy,
					Language = (Languages)Enum.Parse(typeof(Languages), settings.LanguageCd.ToUpper()),
					From = new DateTime(2018, 1, 25)
				});
			}

			


			if (articlesResponse.Status == Statuses.Error) {
				// handle error
				return null;
			}

			return articlesResponse;

		}

		public async Task<SourceResponseDto> GetSources() {

			// get user settings, this should be using the current user Id in the future
			UserSettings settings = await userSettingsService.Get();


			HttpResponseMessage response = await client.GetAsync(String.Format("sources?apiKey=a96df9dbc6624717932b21dabce240d5"));
			response.EnsureSuccessStatusCode();

			var sourceResponse = await response.Content.ReadAsAsync<SourceResponseDto>();

			SourceDto auxSource;

			settings.SourcesIds.Split(',').ToList().ForEach(x => {
				auxSource = sourceResponse.Sources.Find(y => { return y.Id == x; });
				if (auxSource!=null) {
					auxSource.IsSelected = true;
				}
			});

			return sourceResponse;
		}

	}
}
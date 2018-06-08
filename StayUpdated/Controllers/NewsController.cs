using NewsAPI.Models;
using StayUpdated.Interfaces;
using StayUpdated.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StayUpdated.Controllers {
	public class NewsController : Controller {
		private readonly INewsService newsService;
		private readonly IUserSettingsService userSettingsService;

		public NewsController(INewsService _newsService, IUserSettingsService _userSettingsService) {
			newsService = _newsService;
			userSettingsService = _userSettingsService;
		}

		// GET: News
		[HttpGet]
		public async Task<ActionResult> Index(string query) {
			var result = await newsService.GetAll(query);
			var sourceResponseDto = await newsService.GetSources();

			if (result == null) {
				//this means there are no news according to filter criteria
				result = new ArticlesResult();
				result.Articles = new List<Article>();
				result.TotalResults = 0;
			}

			NewsViewModel viewModel = new NewsViewModel() {
				Articles = result.Articles,
				Sources = sourceResponseDto.Sources,
				Total = result.TotalResults
			};

			return View(viewModel);
		}

		// POST: Sources
		[HttpPost]
		public ActionResult Sources(NewsViewModel model) {
			List<string> ids = new List<string>();
			model.Sources.ForEach(s => {
				if (s.IsSelected) {
					ids.Add(s.Id);
				}
			});
			
			userSettingsService.UpdateSources(ids);
			return RedirectToAction("Index");
		}


	}
}

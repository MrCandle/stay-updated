using NewsAPI.Constants;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading;

namespace StayUpdated.Models {
	public class UserSettings {

		[Key]
		public int Id { get; set; }

		public string SourcesIds { get; set; } = "";
		public string LocationCd { get; set; } = new RegionInfo(Thread.CurrentThread.CurrentUICulture.LCID).TwoLetterISORegionName;
		public string LanguageCd { get; set; } = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
		public SortBys SortBy { get; set; } = SortBys.Popularity;
		public int Page { get; set; } = 1;
		public int PageSize { get; set; } = 20;

	}
}
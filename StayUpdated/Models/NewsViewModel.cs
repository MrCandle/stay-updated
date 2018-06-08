using NewsAPI.Models;
using StayUpdated.DTO;
using System.Collections.Generic;

namespace StayUpdated.Models {
	public class NewsViewModel {

		public List<SourceDto> Sources { get; set; }
		public List<Article> Articles { get; set; }
		public int Total { get; set; }
	}
}
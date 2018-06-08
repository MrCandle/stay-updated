using NewsAPI.Models;
using StayUpdated.DTO;
using System.Threading.Tasks;

namespace StayUpdated.Interfaces {
	public interface INewsService {

		Task<ArticlesResult> GetAll(string query);
		Task<SourceResponseDto> GetSources();
	}
}

using StayUpdated.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayUpdated.Interfaces {
	public interface IUserSettingsService {
		Task<int> UpdateSources(List<string> ids);
		Task<UserSettings> Get();
	}
}

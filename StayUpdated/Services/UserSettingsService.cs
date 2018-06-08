using StayUpdated.DAL;
using StayUpdated.Interfaces;
using StayUpdated.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StayUpdated.Services {
	public class UserSettingsService : IUserSettingsService {
		private StayUpdatedContext db = new StayUpdatedContext();

		public async Task<UserSettings> Get() {
			return await(from s in db.UserSettings
						 where s.Id.Equals(1)
						 select s).FirstOrDefaultAsync();

		}
		
		public async Task<int> UpdateSources(List<string> ids) {
			UserSettings currentSettings = await Get();
			currentSettings.SourcesIds = String.Join(",", ids);
			return await db.SaveChangesAsync();
		}
	}
}
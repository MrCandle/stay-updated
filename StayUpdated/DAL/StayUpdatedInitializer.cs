using StayUpdated.Models;
using System.Data.Entity;

namespace StayUpdated.DAL {
	public class StayUpdatedInitializer : DropCreateDatabaseIfModelChanges<StayUpdatedContext> {

		protected override void Seed(StayUpdatedContext context) {
			base.Seed(context);

			var settings = new UserSettings();
			settings.Id = 1;
			context.UserSettings.Add(settings);
			context.SaveChanges();
		}
	}
}
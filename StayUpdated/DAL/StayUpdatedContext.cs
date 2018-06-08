using StayUpdated.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StayUpdated.DAL {
	public class StayUpdatedContext : DbContext {

		public StayUpdatedContext() : base("StayUpdatedContext") {
		}

		public DbSet<UserSettings> UserSettings { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
using Microsoft.EntityFrameworkCore;

namespace GameDatabase.Models
{
	public class GameDatabaseContext : DbContext
	{
		public virtual DbSet<Developer> Developers { get; set; }
		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<DeveloperGame> DeveloperGame { get; set; }

		public GameDatabaseContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}
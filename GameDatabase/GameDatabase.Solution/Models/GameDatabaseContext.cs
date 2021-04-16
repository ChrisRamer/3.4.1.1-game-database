using Microsoft.EntityFrameworkCore;

namespace GameDatabase.Models
{
	public class GameDatabaseContext : DbContext
	{
		//public virtual DbSet<XXXXX> YYYYY { get; set; }
		//public virtual DbSet<XXXXX> YYYYY { get; set; }

		public GameDatabaseContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}
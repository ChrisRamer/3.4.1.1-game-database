using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GameDatabase.Models
{
	public class GameDatabaseContextFactory : IDesignTimeDbContextFactory<GameDatabaseContext>
	{

		GameDatabaseContext IDesignTimeDbContextFactory<GameDatabaseContext>.CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			  .SetBasePath(Directory.GetCurrentDirectory())
			  .AddJsonFile("appsettings.json")
			  .Build();

			var builder = new DbContextOptionsBuilder<GameDatabaseContext>();
			string connectionString = configuration.GetConnectionString("DefaultConnection");

			builder.UseMySql(connectionString);

			return new GameDatabaseContext(builder.Options);
		}
	}
}
using System.Collections.Generic;

namespace GameDatabase.Models
{
	public class Game
	{
		public int GameId { get; set; }
		public string Name { get; set; }
		public int DeveloperId { get; set; }
		public virtual ICollection<DeveloperGame> Developers { get; }

		public Game()
		{
			this.Developers = new HashSet<DeveloperGame>();
		}
	}
}
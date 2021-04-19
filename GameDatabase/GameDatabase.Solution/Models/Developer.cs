using System.Collections.Generic;

namespace GameDatabase.Models
{
	public class Developer
	{
		public int DeveloperId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<DeveloperGame> Games { get; set; }

		public Developer()
		{
			this.Games = new HashSet<DeveloperGame>();
		}
	}
}
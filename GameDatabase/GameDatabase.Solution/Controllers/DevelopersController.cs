using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GameDatabase.Models;

namespace GameDatabase.Controllers
{
	public class DevelopersController : Controller
	{
		private readonly GameDatabaseContext _db;

		public DevelopersController(GameDatabaseContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			List<Developer> model = _db.Developers.ToList();
			return View(model);
		}
	}
}
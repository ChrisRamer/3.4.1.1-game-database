using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GameDatabase.Models;

namespace GameDatabase.Controllers
{
	public class GamesController : Controller
	{
		private readonly GameDatabaseContext _db;

		public GamesController(GameDatabaseContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			return View(_db.Games.ToList());
		}
	}
}
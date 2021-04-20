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

		public ActionResult Create()
		{
			ViewBag.DeveloperId = new SelectList(_db.Developers, "DeveloperId", "Name");
			return View();
		}

		[HttpPost]
		public ActionResult Create(Game game, int DeveloperId)
		{
			_db.Games.Add(game);
			if (DeveloperId != 0)
			{
				_db.DeveloperGame.Add(new DeveloperGame() { DeveloperId = DeveloperId, GameId = game.GameId });
			}
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
			return View(thisGame);
		}
	}
}
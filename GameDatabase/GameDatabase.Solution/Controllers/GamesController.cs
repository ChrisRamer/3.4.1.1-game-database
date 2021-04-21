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

		public ActionResult Edit (int id)
		{
			Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
			ViewBag.DeveloperId = new SelectList(_db.Developers, "DeveloperId", "Name");
			return View(thisGame);
		}

		[HttpPost]
		public ActionResult Edit(Game game, int developerId)
		{
			bool duplicate = _db.DeveloperGame.Any(devGame => devGame.DeveloperId == developerId && devGame.GameId == game.GameId);
			if (developerId != 0 && !duplicate)
			{
				_db.DeveloperGame.Add(new DeveloperGame() { DeveloperId = developerId, GameId = game.GameId});
			}
			_db.Entry(game).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
			return View(thisGame);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
			_db.Games.Remove(thisGame);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddDeveloper(int id)
		{
			Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
			ViewBag.DeveloperId = new SelectList(_db.Developers, "DeveloperId", "Name");
			return View(thisGame);
		}

		[HttpPost]
		public ActionResult AddDeveloper(Game game, int developerId)
		{
			bool duplicate = _db.DeveloperGame.Any(devGame => devGame.DeveloperId == developerId && devGame.GameId == game.GameId);
			if (developerId != 0 && !duplicate)
			{
				_db.DeveloperGame.Add(new DeveloperGame() { DeveloperId = developerId, GameId = game.GameId });
			}
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
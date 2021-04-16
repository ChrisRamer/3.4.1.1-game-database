using Microsoft.AspNetCore.Mvc;

namespace GameDatabase.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet("/")]
		public ActionResult Index()
		{
			return View();
		}
	}
}
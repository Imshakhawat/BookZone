using Microsoft.AspNetCore.Mvc;

namespace BookZone.Controllers
{
	public class AuthorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

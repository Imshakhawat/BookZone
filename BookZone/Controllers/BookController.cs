using BookZone.Data;
using BookZone.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookZone.Controllers
{
	public class BookController : Controller
	{

		private readonly AppDbContext _db;

		public BookController(AppDbContext db)
		{
			_db = db;

		}
		public IActionResult Index()
		{
			IEnumerable<Book> bookList = _db.Books;


			return View(bookList);
		}
	}
}

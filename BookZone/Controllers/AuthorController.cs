using BookZone.Data;
using BookZone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookZone.Controllers
{
	public class AuthorController : Controller
	{
        private readonly AppDbContext _db;

        public AuthorController(AppDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
		{
			return View();
		}

        public IActionResult Details(int Id)
        {

            //var author = _db.Authors.Find(Id);
            // var author = _db.Authors.FirstOrDefault(u => u.Id == Id);

            var authorWithBooks = _db.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == Id);

            return View(authorWithBooks);
        }
    }
}

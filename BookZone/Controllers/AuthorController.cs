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



        public IActionResult Edit(int Id)
        {

            //var author = _db.Authors.Find(Id);
            // var author = _db.Authors.FirstOrDefault(u => u.Id == Id);

            var selectedBook = _db.Books.Include(a => a.Author).FirstOrDefault(a => a.Id == Id);

            return View(selectedBook);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book obj)
        {


            var selectedBook = _db.Books.Include(a => a.Author).FirstOrDefault(a => a.Id == obj.Id);

            selectedBook.Title = obj.Title;


            // _db.Books.Update(obj);
            //_db.Add(book);
            _db.SaveChanges();
            //  TempData["success"] = "Category updated successfully";
            // return RedirectToAction("Index");

            return RedirectToAction("Index");
        }





    }
}

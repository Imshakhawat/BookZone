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


        //Get details of that author
        public IActionResult Details(int Id)
        {

            var authorWithBooks = _db.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == Id);

            return View(authorWithBooks);
        }


        //Get the author id to edit
        public IActionResult Edit(int Id)
        {

            var selectedAuthor = _db.Authors.FirstOrDefault(a => a.Id == Id);

            return View(selectedAuthor);
        }


        //POST the edited author
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {


            var selectedAuthor = _db.Authors.FirstOrDefault(a => a.Id == author.Id);

            selectedAuthor.Name = author.Name;
            selectedAuthor.Address = author.Address;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Remove the Author
        public IActionResult Delete(int? id)
        {

            var selectedAuthor = _db.Authors.FirstOrDefault(a => a.Id == id);

            _db.Remove(selectedAuthor);

            _db.SaveChanges();


            return RedirectToAction("Details"); ;
        }




    }
}

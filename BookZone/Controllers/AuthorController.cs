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

            var selectedAuthor = _db.Authors.FirstOrDefault(a => a.Id == Id);

            return View(selectedAuthor);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author obj)
        {


            var selectedAuthor = _db.Authors.FirstOrDefault(a => a.Id == obj.Id);

            selectedAuthor.Name = obj.Name;
            selectedAuthor.Address = obj.Address;


            // _db.Books.Update(obj);
            //_db.Add(book);
            _db.SaveChanges();
            //  TempData["success"] = "Category updated successfully";
            // return RedirectToAction("Index");

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {

            var selectedAuthor = _db.Authors.FirstOrDefault(a => a.Id == id);

            _db.Remove(selectedAuthor);

            _db.SaveChanges();


            return RedirectToAction("Details"); ;
        }




    }
}

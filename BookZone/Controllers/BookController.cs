using BookZone.Data;
using BookZone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookZone.Controllers
{
	public class BookController : Controller
	{

		private readonly AppDbContext _db;

		public BookController(AppDbContext db)
		{
			_db = db;

		}

        //shows the list of all books
		public IActionResult Index()
		{
			IEnumerable<Book> bookList = _db.Books.Include(x => x.Author);


			return View(bookList);
		}

        //shows the details of a book
        public IActionResult Details(int Id)
        {


            var selectedBook = _db.Books.Include(a => a.Author).FirstOrDefault(a => a.Id == Id);

            return View(selectedBook);
        }


        //Get the the book to Edit
        public IActionResult Edit(int Id)
        {



            var selectedBook = _db.Books.Include(a => a.Author).FirstOrDefault(a => a.Id == Id);

            return View(selectedBook);
        }


        //Post the edited book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {


            var selectedBook = _db.Books.Include(a => a.Author).FirstOrDefault(a => a.Id == book.Id);

            selectedBook.Title = book.Title;



            _db.SaveChanges();

            return RedirectToAction("Details");
        }

        //Remove the book
        public IActionResult Delete(int? id)
        {

            var selectedBook = _db.Books.Include(a => a.Author).FirstOrDefault(a => a.Id == id);

            _db.Remove(selectedBook);

            _db.SaveChanges();


            return RedirectToAction("Index"); ;
        }







    }
}

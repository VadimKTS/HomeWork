using Lesson23HomeWork.Models;
using Lesson23HomeWork.Models.EFDto_Lesson23HomeWork;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson23HomeWork.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;

        
        private ApplicationContext db;
        public BooksController(ILogger<BooksController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Books");
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Book book = db.Books.FirstOrDefault(p => p.Id == id);
                if (book != null)
                    return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            db.Books.Update(book);
            db.SaveChanges();
            return RedirectToAction("Books");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Book book = db.Books.FirstOrDefault(p => p.Id == id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return RedirectToAction("Books");
                }
            }
            return NotFound();
        }

        public IActionResult Books()
        {
            var books = db.Books.ToList();
            return View(books);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
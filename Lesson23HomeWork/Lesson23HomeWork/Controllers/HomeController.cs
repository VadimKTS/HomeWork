using Lesson23HomeWork.Models;
using Lesson23HomeWork.Models.EFDto_Lesson23HomeWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace Lesson23HomeWork.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext db;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //LINQ to Objects: применяется для работы с массивами и коллекциями

        //LINQ to Entities: используется при обращении к базам данных через технологию Entity Framework

        //LINQ to XML: применяется при работе с файлами XML

        //LINQ to DataSet: применяется при работе с объектом DataSet

        //Parallel LINQ(PLINQ): используется для выполнения параллельных запросов
        public IActionResult Privacy()
        {
            List<int> intsList = new List<int>(); //for example
            intsList.Add(0);
            intsList.Add(1);
            intsList.Add(2);
            intsList.Remove(0);

            var booksList = new List<Book>()
            {
                new Book{Id = 10, Author = "Anderson", Name = "FairyTales", Description = "" },
                new Book{Id = 5, Author = "Richter", Name = "CLR via C#", Description = "" }
            };

            //var userList = new List<string>
            List<string> userList = new List<string>
            {
                "Vadim",
                "Artem",
                "Andrew",
                "Denis",
                "Andrew",
                "Denis",
                "Anderson",
                "Richter"
            };

            //var testLINQ1 = db.Books.All(u => u.Id > 2);
            //var testLINQ2 = db.Books.Any(u => u.Id > 2);
            var testlinq1 = booksList.All(u => u.Id > 2);
            var testlinq2 = booksList.Any(u => u.Id > 2);
            var testlinq3 = booksList.Count();
            var testlinq4 = booksList.First();
            var testlinq5 = booksList.FirstOrDefault(p => p.Id == 10);
            var testlinq6 = booksList.FirstOrDefault(p => p.Description.Equals(""));
            var testlinq7 = userList.Single(u => u.Equals("Vadim"));
            var testlinq8 = userList.SingleOrDefault(u => u.Equals("Andre"));
            var testlinq9 = booksList.Select(u => new ViewModelBook
            {
                Id = u.Id,
                Author = u.Author,
                Name = u.Name
            }).ToList();
            var testlinq10 = userList.Where(u => u.Equals("Denis") || u.Equals("Anderson"));
            var testlinq11 = booksList.OrderBy(u => u.Author);
            var testlinq12 = booksList.OrderByDescending(u => u.Id);
            var testlinq13 = userList.Skip(2);
            var testlinq14 = userList.Take(3);



            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
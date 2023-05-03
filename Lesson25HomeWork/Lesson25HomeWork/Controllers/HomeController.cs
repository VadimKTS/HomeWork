using Lesson25HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lesson25HomeWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var user = db.Users.ToList();
            return View(user);
        }


        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IndexFormModel user)
        {
            IndexFormModel u1 = db.Users.FirstOrDefault(u => u.Email.Equals(user.Email));
            if (u1 == null)
            {
                user.LastDate = DateTime.Now;
                user.Count = 1;
                db.Users.Add(user);
            }
            else
            {
                u1.LastDate = DateTime.Now;
                u1.Count += 1;
                db.Update(u1);
            }
            db.SaveChanges();
            return RedirectToAction("Privacy");
        }

        public IActionResult Again()
        {
            return RedirectToAction("Index");
        }

        public IActionResult ISeeYou()
        {
            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
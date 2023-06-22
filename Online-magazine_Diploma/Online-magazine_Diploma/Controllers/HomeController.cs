using Microsoft.AspNetCore.Mvc;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Models;
using Online_magazine_Diploma.Models.HomeModels;
using Online_magazine_Diploma.Services.Interfaces;
using System.Diagnostics;

namespace Online_magazine_Diploma.Controllers
{
	public class HomeController : Controller
    {
        private IUserService _userService;
        private ITitelService _titelService;
        private IArticleService _articleService;

        public HomeController(IUserService userService, ITitelService titelService, IArticleService articleService)
        {
            _userService = userService;
            _titelService = titelService;
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            IList<Titel> titels = await _titelService.GetAllTitels();
			var titel = titels.Where(x => x.ActivateDate < DateTime.Now).MaxBy(x => x.ActivateDate);
            if (titel != null)
            {
                var modelTitel = new TitelViewModel()
                {
                    Id = titel.Id,
                    Name = titel.Name,
                    ActivateDate = titel.ActivateDate,
                    ImageAddress = titel.ImageAddress,
                    TopArticles = await _articleService.GetAllArticles(),//поправить
                };
				return View(modelTitel);
			}
            return BadRequest("Что-то пошло не так");
        }

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
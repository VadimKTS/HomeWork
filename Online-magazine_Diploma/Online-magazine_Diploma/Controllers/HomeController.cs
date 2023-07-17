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
        private IArticleTypeService _articleTypeService;

        public HomeController(IUserService userService, ITitelService titelService, IArticleService articleService, IArticleTypeService articleTypeService)
        {
            _userService = userService;
            _titelService = titelService;
            _articleService = articleService;
            _articleTypeService = articleTypeService;
        }

        public async Task<IActionResult> Index()
        {
            IList<Article> articles = await _articleService.GetAllArticlesAsync();
			// сортировка по просмотрам
			articles = articles.OrderByDescending(x => x.CountOfViews).ToList();// сортировка по убыванию

			IList<Article> articlesForTitel = new List<Article>();
            foreach (var article in articles)
            {
                article.ArticleType = await _articleTypeService.GetArticleTypeByIdAsync((Guid)article.ArticleTypeId);
                if (article.ArticleType == null)
                {
                    return BadRequest("Что-то пошло не так!!!");
                }
                else if (!article.ArticleType.IsDeleted && !article.IsDeleted && article.IsApprovedForPublication && articlesForTitel.Count < 5)//изменить на переменную 
                {
					articlesForTitel.Add(article);
                }
            }

			IList<Titel> titels = await _titelService.GetAllTitelsAsync();
			var titel = titels.Where(x => x.ActivateDate < DateTime.Now).MaxBy(x => x.ActivateDate);
			if (titel != null)
            {
                var modelTitel = new TitelViewModel()
                {
                    Id = titel.Id,
                    Name = titel.Name,
                    ActivateDate = titel.ActivateDate,
                    ImageAddress = titel.ImageAddress,
                    TopArticles = articlesForTitel,//поправить
                };
				return View(modelTitel);
			}
            return BadRequest("Что-то пошло не так");
        }

		public async Task<IActionResult> Privacy()
        {
            var articleTypes = await _articleTypeService.GetAllArticleTypesAsync();
            var articles = await _articleService.GetAllArticlesAsync();
            var articleTypesForModel = new List<ArticleType>();

            foreach (var articleType in articleTypes)
            {
                if (!articleType.IsDeleted )
                {
					foreach (var article in articles)
					{
						if (article.IsApprovedForPublication && article.ArticleTypeId.Equals(articleType.Id) && !article.IsDeleted)//не работает правильно !!!
						{
							articleType.Articles.Add(article);
						}
					}
					articleTypesForModel.Add(articleType);
				}
            }
            var model = new MainPageViewModel() { ArticleTypes = articleTypesForModel };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
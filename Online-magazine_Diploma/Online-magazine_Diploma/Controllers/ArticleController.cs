using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Models.ArticleModels;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Controllers
{
	public class ArticleController : Controller
	{
		private IArticleService _articleService;
		private IArticleTypeService _articleTypeService;
		private IUserService _userService;

		public ArticleController(IArticleService articleService, IArticleTypeService articleTypeService, IUserService userService)
		{
			_articleService = articleService;
			_articleTypeService = articleTypeService;
			_userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> AddArticle()
		{
			List<ArticleType> articleTypes = (List<ArticleType>)await _articleTypeService.GetAllArticleTypes();
			articleTypes = articleTypes.Where(x => x.IsDeleted == false).ToList();
			ViewBag.ArticleTypes = new SelectList(articleTypes, "Id", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddArticlePost(AddArticlesViewModel model)
		{
			var user = await _userService.GetUserByEmail(User.Identity.Name);
			if (ModelState.IsValid)
			{
				var article = new Article
				{
					Id = Guid.NewGuid(),
					CreatedDate = DateTime.Now,
					Name = model.Name,
					Description = model.Description,
					Text = model.Text,
					ArticleTypeId = model.ArticleTypeId,
					AuthorUserId = user.Id,
					IsDeleted = false,
					IsEdited = false,
					IsApprovedForPublication = false,
					IsEditNeeded = false,
					AdminDescriptionForEdit = "default",
				};
				await _articleService.CreateArticle(article);
				return RedirectToAction("Articles", "Article");
			}
			else
			{
				return BadRequest("Что-то пошло не так");
			}
		}

		[HttpGet]
		public async Task<IActionResult> Articles()
		{
			IList<Article> articles = await _articleService.GetAllArticles();
			User author = await _userService.GetUserByEmail(User.Identity.Name);
			var viewModel = new List<ArticlesViewModel>();
			foreach (var article in articles)
			{
				if (article.AuthorUserId.Equals(author.Id) && !article.IsDeleted)
				{
					ArticleType type = await _articleTypeService.GetArticleTypeById((Guid)article.ArticleTypeId);
					var newModel = new ArticlesViewModel
								{
									Id = article.Id,
									Name = article.Name,
									Text = article.Text,
									Description = article.Description,
									ArticleTypeName = type.Name,
									IsEditNeeded = article.IsEditNeeded,
									IsApprovedForPublication = article.IsApprovedForPublication,
									AdminDescriptionForEdit = article.AdminDescriptionForEdit,
									IsEdited = article.IsEdited,
								};
					viewModel.Add(newModel);
				}
			}
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> ArticlesForAdmin()
		{
			IList<Article> articles = await _articleService.GetAllArticles();
			var viewArticles = new List<ManageArticlesViewModel>();
			foreach (var item in articles)
			{
				ArticleType type = await _articleTypeService.GetArticleTypeById((Guid)item.ArticleTypeId);
				User user = await _userService.GetUserById((Guid)item.AuthorUserId);
				var article = new ManageArticlesViewModel
				{
					Id = item.Id,
					CreatedDate = item.CreatedDate,
					Name = item.Name,
					Text = item.Text,
					Description = item.Description,
					ArticleTypeId = type.Id,
					ArticleType = type,//!!!
					AuthorUserId = user.Id,
					AuthorUser = user,//!!!
					IsEditNeeded = item.IsEditNeeded,
					IsEdited = item.IsEdited,
					IsDeleted = item.IsDeleted,
					IsApprovedForPublication = item.IsApprovedForPublication,
					AdminDescriptionForEdit = item.AdminDescriptionForEdit,
				};
				if (!article.IsDeleted)
				{
					viewArticles.Add(article);
				}
			}
			return View(viewArticles);
		}

		[HttpPost]
		public async Task<IActionResult> ApprovedForPublicationPost(Guid id)
		{
			Article article = await _articleService.GetArticleById(id);
			article.IsApprovedForPublication = true;
			await _articleService.UpdateArticle(article);
			return RedirectToAction("ArticlesForAdmin");
		}

		[HttpGet]
		public async Task<IActionResult> EditAdminDescription(Guid id)
		{
			Article article = await _articleService.GetArticleById(id);
			var editArticle = new ManageArticlesViewModel
			{
				Id = article.Id,
				Name = article.Name,
				Description = article.Description,
				Text = article.Text,
				AdminDescriptionForEdit = article.AdminDescriptionForEdit,
			};
			return View(editArticle);
		}


		[HttpPost]
		public async Task<IActionResult> EditAdminDescriptionPost(Guid id, string adminDescriptionForEdit)
		{
			Article article = await _articleService.GetArticleById(id);
			if (article != null)
			{
				article.IsEditNeeded = true;
				article.IsEdited = false;
				article.AdminDescriptionForEdit = adminDescriptionForEdit;
				await _articleService.UpdateArticle(article);
				return RedirectToAction("ArticlesForAdmin");
			}
			else 
			{ 
				return BadRequest("Что-то пошло не так"); 
			}
		}

		[HttpGet]
		public async Task<IActionResult> EditArticle(Guid id)
		{
			var article = await _articleService.GetArticleById(id); 
			if (article != null) 
			{
				var articleType = await _articleTypeService.GetArticleTypeById((Guid)article.ArticleTypeId); 
				var tempArticle = new ArticlesViewModel
				{
					Id = article.Id,
					Name = article.Name,
					Description = article.Description,
					Text = article.Text,
					ArticleTypeName = articleType.Name,
					AdminDescriptionForEdit = article.AdminDescriptionForEdit,
					IsEdited = article.IsEdited,
				};
				return View(tempArticle);
			}
			else
			{ 
				return BadRequest("Что-то пошло не так"); 
			}
		}

		[HttpPost]
		public async Task<IActionResult> EditArticlePost(ArticlesViewModel model)
		{
			var article = await _articleService.GetArticleById(model.Id);
			if (ModelState.IsValid)
			{
				article.IsEdited = true;
				article.Name = model.Name;
				article.Description = model.Description;
				article.Text = model.Text;

				await _articleService.UpdateArticle(article);
				return RedirectToAction("Articles");
			}
			else 
			{ 
				return BadRequest("Что-то пошло не так"); 
			}
		}

		[HttpPost]
		public async Task<IActionResult> DeletePost(Guid id)
		{
			var article = await _articleService.GetArticleById(id);
			article.IsDeleted = true;
			await _articleService.UpdateArticle(article);
			return Ok($"Статья \"{article.Name}\" удалена!!! ") ;
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Models.ArticleTypeModels;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Controllers
{
	public class ArticleTypeController : Controller
	{
		private IArticleTypeService _articleTypeService;

		public ArticleTypeController(IArticleTypeService articleTypeService)
		{
			_articleTypeService = articleTypeService;
		}

		[HttpGet]
		public async Task<IActionResult> ArticleTypes()
		{
			if (await _articleTypeService.GetAllArticleTypesAsync() != null)
			{
				IList<ArticleType> articleTypes = await _articleTypeService.GetAllArticleTypesAsync();
				var articleTypesArray = new ManageArticleTypesViewModel[articleTypes.Count];
				int i = 0;
				foreach (var item in articleTypes)
				{
					articleTypesArray[i] = new ManageArticleTypesViewModel
					{
						Id = item.Id,
						Name = item.Name,
						Description = item.Description,
						IsDeleted = item.IsDeleted,
					};
					i++;
				}
			return View(articleTypesArray);
			}
			return BadRequest();
		}

		public  IActionResult AddArticleType()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddArticleTypePost(AddArticleTypesViewModel model)
		{
			if (ModelState.IsValid)
			{
					var articleType = new ArticleType
					{
						Id = Guid.NewGuid(),
						Name = model.Name,
						Description = model.Description,
						IsDeleted = false
					};
					await _articleTypeService.CreateArticleTypeAsync(articleType);
					return RedirectToAction("ArticleTypes", "ArticleType");
			}
			else
			{
				return BadRequest("Что-то пошло не так");
			}
		}

		[HttpPost]
		public async Task<IActionResult> DeleteArticleTypePost(Guid id)
		{
			ArticleType oldArticleType = await _articleTypeService.GetArticleTypeByIdAsync(id);
			if (oldArticleType != null)
			{
				oldArticleType.IsDeleted = true;
				await _articleTypeService.UpdateArticleTypeAsync(oldArticleType);
				return RedirectToAction("ArticleTypes", "ArticleType");
			}
			else
			{
				return BadRequest();
			}
		}

	}
}

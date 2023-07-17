using Microsoft.AspNetCore.Mvc;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Models.ArticleModels;
using Online_magazine_Diploma.Models.CommentModels;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Controllers
{
	public class UserController : Controller
	{
		private IUserService _userService;
		private IArticleService _articleService;
		private ICommentService _commentService;

		public UserController(IUserService userService, IArticleService articleService, ICommentService commentService)
		{
			_userService = userService;
			_articleService = articleService;
			_commentService = commentService;
		}

		public IActionResult PersonalAccount()
		{
			return View();
		}

		public async Task<IActionResult> ReadArticle(Guid id) 
		{
			var article = await _articleService.GetArticleByIdAsync(id);
			article.CountOfViews += 1;
			await _articleService.UpdateArticleAsync(article);
			IList<Comment> comments = await _commentService.GetCommentsByArticleIdAsync(id);
			if (comments == null)
			{
				return NotFound("У этой статьи нет комментариев");
			}

			foreach (var item in comments)
			{
				item.User = await _userService.GetUserByIdAsync((Guid)item.UserId);
			}
					
			article.Comments = comments.OrderBy(x => x.CreatedDate).ToList();
			article.AuthorUser = await _userService.GetUserByIdAsync((Guid)article.AuthorUserId);

			var viewModel = new ReadArticlesViewModel() 
			{ 
				Id = article.Id,
				AuthorUserId = article.AuthorUserId,
				Description = article.Description,
				AuthorUser = article.AuthorUser,
				AdminDescriptionForEdit = article.AdminDescriptionForEdit,
				ArticleType = article.ArticleType,
				Rating = article.Rating,
				ArticleTypeId = article.ArticleTypeId,
				Comments = article.Comments,
				CountOfViews = article.CountOfViews,
				CreatedDate = article.CreatedDate,
				IsApprovedForPublication = article.IsApprovedForPublication,
				Text = article.Text,
				IsDeleted = article.IsDeleted,
				TitelId = article.TitelId,
				IsEdited = article.IsEdited,
				IsEditNeeded = article.IsEditNeeded,
				Name = article.Name,
			};

			return View(viewModel);// скорректировать
		}

		public async Task<IActionResult> AddComment()
		{
			return View();
		}

		public async Task<IActionResult> AddCommentPost(CommentViewModel model)
		{
			var user = await _userService.GetUserByEmailAsync(model.UserEmail);

			if (user != null)
			{
			var newComment = new Comment()
				{
					Id = Guid.NewGuid(),
					CreatedDate = DateTime.Now,
					ArticleId = model.ArticleId,
					Text = model.Text,
					UserId = user.Id,
					IsDeleted = false,
					IsEdited = false,
				};
				await _commentService.CreateCommentAsync(newComment);
			}
			else 
			{ 
				return BadRequest("Что-то пошло не так");
			}

			return RedirectToAction("ReadArticle", new { id = model.ArticleId });
		}


	}
}

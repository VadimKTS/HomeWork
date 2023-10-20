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

        [HttpGet(Name = "AddArticle")]
        public async Task<IActionResult> AddArticle()
        {
            List<ArticleType> articleTypes = (List<ArticleType>)await _articleTypeService.GetAllArticleTypesAsync();
            articleTypes = articleTypes.Where(x => x.IsDeleted == false).ToList();
            ViewBag.ArticleTypes = new SelectList(articleTypes, "Id", "Name");
            return View();
        }

        [HttpPost(Name = "AddArticlePost")]
        public async Task<IActionResult> AddArticlePost(AddArticlesViewModel model)
        {
            var user = await _userService.GetUserByEmailAsync(User.Identity.Name);
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
                await _articleService.CreateArticleAsync(article);
                return RedirectToAction("Articles", "Article");
            }
            else
            {
                return BadRequest("Что-то пошло не так");
            }
        }

        [HttpGet(Name = "Articles")]
        public async Task<IActionResult> Articles()
        {
            IList<Article> articles = await _articleService.GetAllArticlesAsync();
            User author = await _userService.GetUserByEmailAsync(User.Identity.Name);
            var viewModel = new List<ArticlesViewModel>();
            foreach (var article in articles)
            {
                if (article.AuthorUserId.Equals(author.Id) && !article.IsDeleted)
                {
                    ArticleType type = await _articleTypeService.GetArticleTypeByIdAsync((Guid)article.ArticleTypeId);
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

        [HttpGet(Name = "ArticlesForAdmin")]
        public async Task<IActionResult> ArticlesForAdmin()
        {
            IList<Article> articles = await _articleService.GetAllArticlesAsync();
            var viewArticles = new List<ManageArticlesViewModel>();
            foreach (var item in articles)
            {
                ArticleType type = await _articleTypeService.GetArticleTypeByIdAsync((Guid)item.ArticleTypeId);
                User user = await _userService.GetUserByIdAsync((Guid)item.AuthorUserId);
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

        [HttpPost(Name = "ApprovedForPublicationPost")]
        public async Task<IActionResult> ApprovedForPublicationPost(Guid id)
        {
            Article article = await _articleService.GetArticleByIdAsync(id);
            article.IsApprovedForPublication = true;
            await _articleService.UpdateArticleAsync(article);
            return RedirectToAction("ArticlesForAdmin");
        }

        [HttpGet(Name = "EditAdminDescription")]
        public async Task<IActionResult> EditAdminDescription(Guid id)
        {
            Article article = await _articleService.GetArticleByIdAsync(id);
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


        [HttpPost(Name = "EditAdminDescriptionPost")]
        public async Task<IActionResult> EditAdminDescriptionPost(Guid id, string adminDescriptionForEdit)
        {
            Article article = await _articleService.GetArticleByIdAsync(id);
            if (article != null)
            {
                article.IsEditNeeded = true;
                article.IsEdited = false;
                article.AdminDescriptionForEdit = adminDescriptionForEdit;
                await _articleService.UpdateArticleAsync(article);
                return RedirectToAction("ArticlesForAdmin");
            }
            else
            {
                return BadRequest("Что-то пошло не так");
            }
        }

        [HttpGet(Name = "EditArticle")]
        public async Task<IActionResult> EditArticle(Guid id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            if (article != null)
            {
                var articleType = await _articleTypeService.GetArticleTypeByIdAsync((Guid)article.ArticleTypeId);
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

        [HttpPost(Name = "EditArticlePost")]
        public async Task<IActionResult> EditArticlePost(ArticlesViewModel model)
        {
            var article = await _articleService.GetArticleByIdAsync(model.Id);
            if (ModelState.IsValid)
            {
                article.IsEdited = true;
                article.Name = model.Name;
                article.Description = model.Description;
                article.Text = model.Text;

                await _articleService.UpdateArticleAsync(article);
                return RedirectToAction("Articles");
            }
            else
            {
                return BadRequest("Что-то пошло не так");
            }
        }

        [HttpPost(Name = "DeletePost")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            article.IsDeleted = true;
            await _articleService.UpdateArticleAsync(article);
            return Ok($"Статья \"{article.Name}\" удалена!!! ");
        }
    }
}

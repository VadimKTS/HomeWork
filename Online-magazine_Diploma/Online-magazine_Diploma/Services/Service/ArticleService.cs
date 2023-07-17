using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Services.Service
{
	public class ArticleService : ServiceConstructor, IArticleService
	{
		public ArticleService(IUnitOfWork unitOfWork) : base(unitOfWork) 
		{

		}

		public async Task<Article> CreateArticleAsync(Article article)
		{
			return await UnitOfWork.Articles.CreateAsync(article);
		}

		public async Task<Article> GetArticleByIdAsync(Guid id)
		{
			IList<Article> articles = await UnitOfWork.Articles.GetAllAsync();
			return articles.FirstOrDefault(x => x.Id == id);
		}

		public async Task<IList<Article>> GetAllArticlesAsync()
		{
			var articles = await UnitOfWork.Articles.GetAllAsync();
			return articles;
		}

		public async Task UpdateArticleAsync(Article article)
		{
			await UnitOfWork.Articles.UpdateAsync(article);
		}
	}
}

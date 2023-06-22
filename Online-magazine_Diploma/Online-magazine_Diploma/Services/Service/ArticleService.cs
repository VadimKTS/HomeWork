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

		public async Task<Article> CreateArticle(Article article)
		{
			return await UnitOfWork.Articles.Create(article);
		}

		public async Task<Article> GetArticleById(Guid id)
		{
			IList<Article> articles = await UnitOfWork.Articles.GetAll();
			return articles.FirstOrDefault(x => x.Id == id);
		}

		public async Task<IList<Article>> GetAllArticles()
		{
			IList<Article> articles = await UnitOfWork.Articles.GetAll();
			return articles;
		}

		public async Task UpdateArticle(Article article)
		{
			await UnitOfWork.Articles.Update(article);
		}

		public async Task DeleteArticle(Article article)
		{
			await UnitOfWork.Articles.Delete(article);
		}
	}
}

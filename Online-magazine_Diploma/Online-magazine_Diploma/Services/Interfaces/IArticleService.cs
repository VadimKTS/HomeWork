using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface IArticleService
	{
		Task<Article> GetArticleById(Guid id);
		Task<IList<Article>> GetAllArticles();
		Task<Article> CreateArticle(Article article);
		Task UpdateArticle(Article article);
		Task DeleteArticle(Article article);
	}
}

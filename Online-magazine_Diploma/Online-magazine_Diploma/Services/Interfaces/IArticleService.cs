using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface IArticleService
	{
		Task<Article> GetArticleByIdAsync(Guid id);
		Task<IList<Article>> GetAllArticlesAsync();
		Task<Article> CreateArticleAsync(Article article);
		Task UpdateArticleAsync(Article article);
	}
}

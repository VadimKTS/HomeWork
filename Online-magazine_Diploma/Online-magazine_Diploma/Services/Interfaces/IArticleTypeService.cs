using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface IArticleTypeService
	{
		Task<ArticleType> GetArticleTypeByIdAsync(Guid id);
		Task<IList<ArticleType>> GetAllArticleTypesAsync();
		Task<ArticleType> CreateArticleTypeAsync(ArticleType articleType);
		Task UpdateArticleTypeAsync(ArticleType articleType);
	}
}

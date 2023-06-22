using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface IArticleTypeService
	{
		Task<ArticleType> GetArticleTypeById(Guid id);
		Task<IList<ArticleType>> GetAllArticleTypes();
		Task<ArticleType> CreateArticleType(ArticleType articleType);
		Task UpdateArticleType(ArticleType articleType);
		Task DeleteArticleType(ArticleType articleType);
	}
}

using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Services.Service
{
	public class ArticleTypeService : ServiceConstructor, IArticleTypeService
	{
		public ArticleTypeService(IUnitOfWork unitOfWork) : base(unitOfWork) 
		{

		}

		public async Task<ArticleType> CreateArticleTypeAsync(ArticleType articleType)
		{
			return await UnitOfWork.ArticleTypes.CreateAsync(articleType);
		}

		public async Task<ArticleType> GetArticleTypeByIdAsync(Guid id)
		{
			IList<ArticleType> articleTypes = await UnitOfWork.ArticleTypes.GetAllAsync();
			return articleTypes.FirstOrDefault(x => x.Id == id);
		}

		public async Task<IList<ArticleType>> GetAllArticleTypesAsync()
		{
			IList<ArticleType> articleTypes = await UnitOfWork.ArticleTypes.GetAllAsync();
			return articleTypes;
		}

		public async Task UpdateArticleTypeAsync(ArticleType articleType)
		{
			await UnitOfWork.ArticleTypes.UpdateAsync(articleType);
		}
	}
}

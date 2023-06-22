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

		public async Task<ArticleType> CreateArticleType(ArticleType articleType)
		{
			return await UnitOfWork.ArticleTypes.Create(articleType);
		}

		public async Task<ArticleType> GetArticleTypeById(Guid id)
		{
			IList<ArticleType> articleTypes = await UnitOfWork.ArticleTypes.GetAll();
			return articleTypes.FirstOrDefault(x => x.Id == id);
		}

		public async Task<IList<ArticleType>> GetAllArticleTypes()
		{
			IList<ArticleType> articleTypes = await UnitOfWork.ArticleTypes.GetAll();
			return articleTypes;
		}

		public async Task UpdateArticleType(ArticleType articleType)
		{
			await UnitOfWork.ArticleTypes.Update(articleType);
		}

		public async Task DeleteArticleType(ArticleType articleType)
		{
			await UnitOfWork.ArticleTypes.Delete(articleType);
		}
	}
}

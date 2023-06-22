using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Services.Service
{
	public class TitelService : ServiceConstructor, ITitelService
	{
		public TitelService(IUnitOfWork unitOfWork) : base(unitOfWork) 
		{

		}

		public async Task<Titel> CreateTitel(Titel titel)
		{
			return await UnitOfWork.Titels.Create(titel);
		}

		public async Task<Titel> GetTitelById(Guid id)
		{
			IList<Titel> titels = await UnitOfWork.Titels.GetAll();
			return titels.FirstOrDefault(x => x.Id == id);
		}

		public async Task<IList<Titel>> GetAllTitels()
		{
			IList<Titel> titels = await UnitOfWork.Titels.GetAll();
			return titels;
		}

		public async Task UpdateTitel(Titel titel)
		{
			await UnitOfWork.Titels.Update(titel);
		}

		public async Task DeleteTitel(Titel titel)
		{
			await UnitOfWork.Titels.Delete(titel);
		}
	}
}

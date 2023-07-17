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

		public async Task<Titel> CreateTitelAsync(Titel titel)
		{
			return await UnitOfWork.Titels.CreateAsync(titel);
		}

		public async Task<Titel> GetTitelByIdAsync(Guid id)
		{
			IList<Titel> titels = await UnitOfWork.Titels.GetAllAsync();
			return titels.FirstOrDefault(x => x.Id == id);
		}

		public async Task<IList<Titel>> GetAllTitelsAsync()
		{
			IList<Titel> titels = await UnitOfWork.Titels.GetAllAsync();
			return titels;
		}

		public async Task UpdateTitelAsync(Titel titel)
		{
			await UnitOfWork.Titels.UpdateAsync(titel);
		}
	}
}

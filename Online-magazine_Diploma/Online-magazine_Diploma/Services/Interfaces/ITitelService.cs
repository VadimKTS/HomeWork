using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface ITitelService
	{
		Task<Titel> GetTitelByIdAsync(Guid id);
		Task<IList<Titel>> GetAllTitelsAsync();
		Task<Titel> CreateTitelAsync(Titel article);
		Task UpdateTitelAsync(Titel article);
	}
}

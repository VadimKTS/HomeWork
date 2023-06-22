using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface ITitelService
	{
		Task<Titel> GetTitelById(Guid id);
		Task<IList<Titel>> GetAllTitels();
		Task<Titel> CreateTitel(Titel article);
		Task UpdateTitel(Titel article);
		Task DeleteTitel(Titel article);
	}
}

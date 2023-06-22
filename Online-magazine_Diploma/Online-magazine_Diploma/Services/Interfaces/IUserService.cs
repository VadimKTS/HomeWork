using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface IUserService
	{
		Task<User> GetUserByEmail(string email);
		Task<User> GetUserById(Guid id);
		Task<IList<User>> GetAllUsers();
		Task<User> CreateUser(User user);
		Task UpdateUser(User user);

	}
}

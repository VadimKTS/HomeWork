using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface IUserService
	{
		Task<User> GetUserByEmailAsync(string email);
		Task<User> GetUserByIdAsync(Guid id);
		Task<IList<User>> GetAllUsersAsync();
		Task<User> CreateUserAsync(User user);
		Task UpdateUserAsync(User user);

	}
}

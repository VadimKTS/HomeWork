using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Services.Service
{
	public class UserService : ServiceConstructor, IUserService
	{
		public UserService(IUnitOfWork unitOfWork) : base(unitOfWork) 
		{

		}

		public async Task<User> CreateUserAsync(User user)
		{
			return await UnitOfWork.Users.CreateAsync(user);
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			IList<User> users = await UnitOfWork.Users.GetAllAsync();
			return users.FirstOrDefault(x => x.Email == email && x.IsDeleted != true);
		}

		public async Task<User> GetUserByIdAsync(Guid id)
		{
			IList<User> users = await UnitOfWork.Users.GetAllAsync();
			return users.FirstOrDefault(x => x.Id == id);
		}

		public async Task<IList<User>> GetAllUsersAsync()
		{
			IList<User> users = await UnitOfWork.Users.GetAllAsync();
			return users;
		}

		public async Task UpdateUserAsync(User user)
		{
			await UnitOfWork.Users.UpdateAsync(user);
		}
	}
}

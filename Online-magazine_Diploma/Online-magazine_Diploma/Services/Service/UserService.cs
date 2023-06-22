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

		public async Task<User> CreateUser(User user)
		{
			return await UnitOfWork.Users.Create(user);
		}

		public async Task<User> GetUserByEmail(string email)
		{
			IList<User> users = await UnitOfWork.Users.GetAll();
			return users.FirstOrDefault(x => x.Email == email && x.IsDeleted != true);
		}

		public async Task<User> GetUserById(Guid id)
		{
			IList<User> users = await UnitOfWork.Users.GetAll();
			return users.FirstOrDefault(x => x.Id == id);
		}

		public async Task<IList<User>> GetAllUsers()
		{
			IList<User> users = await UnitOfWork.Users.GetAll();
			return users;
		}

		public async Task UpdateUser(User user)
		{
			await UnitOfWork.Users.Update(user);
		}
	}
}

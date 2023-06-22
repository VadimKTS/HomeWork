using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;

namespace Online_magazine_Diploma.Services.Service
{
	public class ServiceConstructor
	{
		protected IUnitOfWork UnitOfWork;

		protected ServiceConstructor(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}
	}
}

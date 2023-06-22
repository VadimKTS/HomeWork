using Microsoft.AspNetCore.Mvc;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Controllers
{
	public class RatingController : Controller
	{
		private IConfiguration _configuration;
		private IUserService _userService;

		public RatingController(IConfiguration configuration, IUserService userService)
		{
			_configuration = configuration;
			_userService = userService;
		}
	}
}

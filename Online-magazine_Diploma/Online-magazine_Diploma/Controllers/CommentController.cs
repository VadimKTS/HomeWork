using Microsoft.AspNetCore.Mvc;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Controllers
{
	public class CommentController : Controller
	{
		private IConfiguration _configuration;
		private IUserService _userService;

		public CommentController(IConfiguration configuration, IUserService userService)
		{
			_configuration = configuration;
			_userService = userService;
		}
	}
}

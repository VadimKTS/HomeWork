using Microsoft.AspNetCore.Mvc;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Models.AdministratorModels;
using Online_magazine_Diploma.Services.Interfaces;

namespace Online_magazine_Diploma.Controllers
{
	public class AdministratorController : Controller
	{
		private IUserService _userService;
		private ITitelService _titelService;

		public AdministratorController(IUserService userService, ITitelService titelService)
		{
			_userService = userService;
			_titelService = titelService;
		}


		public async Task<IActionResult> PersonalAccount()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> ManageUsers()
		{
			IList<User> users = await _userService.GetAllUsersAsync();
			var tempUsers = new ManageUsersViewModel[users.Count];
			int i = 0;
			foreach (var item in users)
			{
				tempUsers[i] = new ManageUsersViewModel {
					Id = item.Id,
					Name = item.Name,
					Email = item.Email,
					UserRole = item.UserRole,
					IsDeleted = item.IsDeleted,
					Comments = item.Comments,
					Ratings = item.Rating,
					Articles = item.Article,
				};
				i++;
			}
			return View(tempUsers);
		}



		[HttpGet]
		public async Task<IActionResult> EditUserRole(Guid id)
		{
			User user = await _userService.GetUserByIdAsync(id);
			var editUser = new ManageUsersViewModel
			{
				Id = user.Id,
				Name = user.Name,
				Email = user.Email,
				UserRole = user.UserRole,
				IsDeleted = user.IsDeleted,
				Comments = user.Comments,
				Ratings = user.Rating,
				Articles = user.Article,

			};
			return View(editUser);
		}



		[HttpPost]
		public async Task<IActionResult> EditUserRolePost(ManageUsersViewModel model)
		{
			User oldUser = await _userService.GetUserByIdAsync(model.Id);
			if (oldUser != null)
			{
				oldUser.UserRole = model.UserRole;
				await _userService.UpdateUserAsync(oldUser);
				return RedirectToAction("ManageUsers", "Administrator");
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> DeleteUserPost(Guid id)
		{
			User oldUser = await _userService.GetUserByIdAsync(id);
			if (oldUser != null && !oldUser.UserRole.Equals(UserRole.Administrator))
			{
				oldUser.IsDeleted = true;
				await _userService.UpdateUserAsync(oldUser);
				return RedirectToAction("ManageUsers", "Administrator");
			}
			else if (oldUser.UserRole.Equals(UserRole.Administrator))
			{
                return BadRequest("Нет доступа! Невозможно удалить администратора.");
            }
			{
				return BadRequest("Что-то пошло не так!");
			}
		}

		[HttpGet]
		public async Task<IActionResult> AddTitel()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddTitelPost(AddTitelViewModel model)
		{
			if (ModelState.IsValid) 
			{
				var titel = new Titel()
				{
					Id = Guid.NewGuid(),
					Name = model.Name,
					ActivateDate = model.ActivateDate,
					ImageAddress = model.ImageAddress,
				};
				_titelService.CreateTitelAsync(titel);

				return RedirectToAction("PersonalAccount", "Administrator");
			}
			else 
			{ 
				return BadRequest("Что-то пошло не так"); 
			}
		}

	}
}

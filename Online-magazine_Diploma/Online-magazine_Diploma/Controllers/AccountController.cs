using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.KDF;
using Online_magazine_Diploma.Models.AccountModels;
using Online_magazine_Diploma.Services.Interfaces;
using System.Security.Claims;

namespace Online_magazine_Diploma.Controllers
{
	public class AccountController : Controller
	{
		private IConfiguration _configuration;
		private IUserService _userService;

		public AccountController(IConfiguration configuration, IUserService userService)
		{
			_configuration = configuration;
			_userService = userService;
		}
				
		public IActionResult Login()
		{
			return View();
		}

        [AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> LoginPost(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				IActionResult response = Unauthorized();
				User user = await _userService.GetUserByEmailAsync(model.Email);
				if (user != null && HashPasswordKDF.VerifyHashedPassword(user.PasswordHash, model.Password))
				{
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(Authenticate(user)));
					response = RedirectToAction("PersonalAccount", "User");
					if (user.UserRole.Equals(UserRole.VipUser) && user.VipStatusEnd < DateTime.Now) 
					{ 
						user.UserRole = UserRole.User;
						await _userService.UpdateUserAsync(user);
					}
				}
				else
				{
					response = BadRequest("Неверный пароль или Email ");
				}
				return response;
			}
			else
			{
				return BadRequest();
			}
		}

		public IActionResult Registration()
		{
			return View();
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> RegistrationPost(RegistrationViewModel model)
		{
			if (ModelState.IsValid)
			{
				var userValid = await _userService.GetUserByEmailAsync(model.Email);
				if (userValid == null && model.Password.Equals(model.ConfirmPassword))
				{
					var user = new User
					{
						Id = Guid.NewGuid(),
						Name = model.Name,
						Email = model.Email,
						PhoneNumber = model.PhoneNumber,
						PasswordHash = HashPasswordKDF.HashPassword(model.ConfirmPassword),
						IsDeleted = false,
						UserRole = UserRole.User,
						VipStatusEnd = DateTime.Now,
					};
					await _userService.CreateUserAsync(user);
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(Authenticate(user)));
					return RedirectToAction("PersonalAccount", "User");
				}
				else
				{
					return BadRequest($"Пользователь с почтой {model.Email} уже зарегистрирован");
				}
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> LogoutPost()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("PersonalAccount", "User");
		}
		//----------------------------------------------
		private ClaimsIdentity Authenticate(User user)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole.ToString())
			};
			return new ClaimsIdentity(claims, "ApplicationCookie",
				ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
		}
		//------------------------------------------------
		[HttpGet]
		//[Authorize]
		public async Task<IActionResult> EditUser()
		{
			User user = await _userService.GetUserByEmailAsync(User.Identity.Name);
			var editUser = new EditUserViewModel
			{
				Name = user.Name,
				PhoneNumber = user.PhoneNumber
			};
			return View(editUser);
		}



		[HttpPost]
		//[Authorize]
		public async Task<IActionResult> EditUserPost(EditUserViewModel model)
		{
			User oldUser = await _userService.GetUserByEmailAsync(User.Identity.Name);
			if (oldUser != null)
			{
				oldUser.Name = model.Name;
				oldUser.PhoneNumber = model.PhoneNumber;
				if (model.OldPassword != null && model.NewPassword != null && HashPasswordKDF.VerifyHashedPassword(model.OldPassword, oldUser.PasswordHash)) oldUser.PasswordHash = HashPasswordKDF.HashPassword(model.NewPassword);
				await _userService.UpdateUserAsync(oldUser);
				return RedirectToAction("PersonalAccount", "User");
			}
			else
			{
				return BadRequest();
			}
		}

		public async Task<IActionResult> BeVip()
		{
			User user = await _userService.GetUserByEmailAsync(User.Identity.Name);
			if (user != null)
			{
				var model = new BeVipViewModel
				{
					Email = user.Email,
				};
				return View(model);
			}
			return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> BeVipPost(BeVipViewModel model)
		{
			if (ModelState.IsValid) 
			{ 
				User user = await _userService.GetUserByEmailAsync(model.Email);
				if (user != null)
				{
					user.UserRole = UserRole.VipUser;
					if (user.VipStatusEnd < DateTime.Now)
					{
						user.VipStatusEnd = DateTime.Now.AddDays(30);
					}
					else
					{
						user.VipStatusEnd.AddDays(30);
					}
					await _userService.UpdateUserAsync(user);
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
							new ClaimsPrincipal(Authenticate(user)));
					return RedirectToAction("PersonalAccount", "User");
				}
			}
			return BadRequest("Что-то пошло не так!");
		}
	}
}

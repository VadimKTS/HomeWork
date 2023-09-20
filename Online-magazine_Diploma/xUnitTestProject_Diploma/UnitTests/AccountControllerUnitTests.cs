using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NuGet.Protocol;
using Online_magazine_Diploma.Controllers;
using Online_magazine_Diploma.Models.AccountModels;
using Online_magazine_Diploma.Models.CommentModels;
using Online_magazine_Diploma.Services.Interfaces;
using Online_magazine_Diploma.Services.Service;

namespace xUnitTestProject_Diploma.UnitTests
{
    public class AccountControllerUnitTests
    {
        private IConfiguration _configuration;
        private IUserService _userService;

        [Fact]
		public void Login_NotNull_ReturnsView()
		{
			// Arrange
			var sut = new AccountController(_configuration, _userService );
			// Act
			var result = sut.Login();
			// Assert
			Assert.NotNull(result);
		}

        [Fact]
        public void LoginPost_NotNull_ReturnsResponse()
        {
            // Arrange
            var sut = new AccountController(_configuration, _userService);
			var model = new LoginViewModel() { Email = "testEmail@mail.com", Password = "qwerty"};
            // Act
            var result = sut.LoginPost(model);
            // Assert
            Assert.NotNull(result);
			Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Registration_NotNull_ReturnsResponse()
        {
            // Arrange
            var sut = new AccountController(_configuration, _userService);            
            var result = sut.Registration();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
		public void RegistrationPost_NotNull_ReturnsResponse()
		{
            // Arrange
            var sut = new AccountController(_configuration, _userService);
            var model = new RegistrationViewModel() 
            { 
                Email = "testEmail@mail.com", 
                Password = "qwerty", 
                ConfirmPassword = "qwerty", 
                Name = "testName",
                PhoneNumber = "+375291234567",
            };
            var result = sut.RegistrationPost(model);
            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }
	}
}
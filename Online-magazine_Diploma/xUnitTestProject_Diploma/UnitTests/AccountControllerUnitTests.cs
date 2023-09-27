using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Online_magazine_Diploma.Controllers;
using Online_magazine_Diploma.Models.AccountModels;
using Online_magazine_Diploma.Services.Interfaces;

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
        public void Registration_NotNull_ReturnsView()
        {
            // Arrange
            var sut = new AccountController(_configuration, _userService);
            // Act
            var result = sut.Registration();
            // Assert
            Assert.NotNull(result);
            Assert.True(result is ActionResult);
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
            // Act
            var result = sut.RegistrationPost(model);
            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void LogoutPost_NotNull_ReturnsResponse() 
        {
            // Arrange
            var sut = new AccountController(_configuration, _userService);
            // Act
            var result = sut.LogoutPost();
            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void EditUser_NotNull_ReturnsView()
        {
            // Arrange
            var sut = new AccountController(_configuration, _userService);
            // Act
            var result = sut.EditUser();
            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
            Assert.True(result is Task<IActionResult>);
        }

        [Fact]
        public void EditUserPost_NotNull_ReturnsResponse()
        {
            // Arrange
            var sut = new AccountController(_configuration, _userService);
            var model = new EditUserViewModel() 
            { 
                Name = "testName", 
                NewPassword = "qwerty", 
                OldPassword = "qwerty123", 
                PhoneNumber = "1234567890" 
            };
            // Act
            var result = sut.EditUserPost(model);
            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void BeVip_NotNull_ReturnsView()
        {
            // Arrange
            var sut = new AccountController(_configuration, _userService);
            // Act
            var result = sut.BeVip();
            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void BeVipPost_NotNull_ReturnsView()
        {
            // Arrange
            var sut = new AccountController(_configuration, _userService);
            var model = new BeVipViewModel()
            {
                CardHolderName = "Test",
                CreditCard = "",
                CvvCode = "1234567890",
                Email = "",
                Expires = "",
            };
            // Act
            var result = sut.BeVipPost(model);
            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }
    }
}
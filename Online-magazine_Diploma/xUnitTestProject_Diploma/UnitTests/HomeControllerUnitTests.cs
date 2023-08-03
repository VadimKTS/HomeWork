using Microsoft.AspNetCore.Mvc;
using Online_magazine_Diploma.Controllers;
using Online_magazine_Diploma.Services.Interfaces;
using Online_magazine_Diploma.Services.Service;

namespace xUnitTestProject_Diploma.UnitTests
{
    public class HomeControllerUnitTests
	{
		private IUserService _userService;
		private ITitelService _titelService;
		private IArticleService _articleService;
		private IArticleTypeService _articleTypeService;

		[Fact]
		public void Index_NotNull_ReturnsView()
		{
			// Arrange
			var sut = new HomeController( _userService, _titelService, _articleService, _articleTypeService );
			// Act
			var result = sut.Index();
			// Assert
			Assert.NotNull(result);
		}

		[Fact]
		public void Privacy_NotNull_ReturnsView() 
		{
			// Arrange
			var sut = new HomeController(_userService, _titelService, _articleService, _articleTypeService);
			// Act
			var result = sut.Privacy();
			// Assert
			Assert.NotNull(result);
			Assert.True(result.IsCompleted);
		}
    }
}
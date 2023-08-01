using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Online_magazine_Diploma.Controllers;
using Online_magazine_Diploma.Models.CommentModels;
using Online_magazine_Diploma.Services.Interfaces;
using Online_magazine_Diploma.Services.Service;

namespace xUnitTestProject_Diploma.UnitTests
{
    public class UserControllerUnitTests
	{
		private IUserService _userService;
		private IArticleService _articleService;
		private ICommentService _commentService;

		[Fact]
		public void ReadArticle_NotNull_ReturnsView()
		{
			// Arrange
			var sut = new UserController( _userService, _articleService, _commentService );
			var id = Guid.Parse("D60B91AA-E310-4F3E-A3D1-F3AE4212472F");// Guid из базы
			// Act
			var result = sut.ReadArticle(id);
			// Assert
			Assert.NotNull(result);
		}

		[Fact]
		public void AddCommentPost_NotNull_ReturnsTestComment()
		{
			// Arrange
			var sut = new UserController(_userService, _articleService, _commentService);
			var testModel = new CommentViewModel
			{
				Id = Guid.NewGuid(),
				Text = "Test",
				CreatedDate = DateTime.Now,
				ArticleId = Guid.Parse("D60B91AA-E310-4F3E-A3D1-F3AE4212472F"),// Guid из базы
				UserId = Guid.Parse("21C8053D-8CF1-484B-8559-C3DE0DD037EF"),
		};
			// Act
			var result = sut.AddCommentPost(testModel);
			// Assert
			Assert.NotNull(result);
		}
	}
}
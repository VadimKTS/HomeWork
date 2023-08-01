using Online_magazine_Diploma.Controllers;
using Xunit;

namespace UnitTest_Diploma.Tests
{
	public class HomeControllerTests
	{
		[Fact]
		public void IndexViewResultNotNull()
		{
			// Arrange
			HomeController controller = new HomeController();
			// Act
			ViewResult result = controller.Index() as ViewResult;
			// Assert
			Assert.NotNull(result);
		}
	}
}
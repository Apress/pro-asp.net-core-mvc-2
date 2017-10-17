using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllersAndActions.Tests {

    public class ActionTests {



        //[Fact]
        //public void JsonActionMethod() {
        //    // Arrange
        //    ExampleController controller = new ExampleController();
        //    // Act 
        //    JsonResult result = controller.Index();
        //    // Assert
        //    Assert.Equal(new[] { "Alice", "Bob", "Joe" }, result.Value);
        //}

        [Fact]
        public void NotFoundActionMethod() {
            // Arrange
            ExampleController controller = new ExampleController();
            // Act 
            StatusCodeResult result = controller.Index();
            // Assert
            Assert.Equal(404, result.StatusCode);
        }

    }
}

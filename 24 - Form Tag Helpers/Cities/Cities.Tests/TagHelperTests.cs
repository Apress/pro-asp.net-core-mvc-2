using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cities.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace Cities.Tests {

    public class TagHelperTests {

        [Fact]
        public void TestTagHelper() {
            // Arrange
            var context = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                "myuniqueid");

            var output = new TagHelperOutput("button",
                new TagHelperAttributeList(), (cache, encoder) =>
                    Task.FromResult<TagHelperContent>
                        (new DefaultTagHelperContent()));

            // Act
            var tagHelper = new ButtonTagHelper {
                BsButtonColor = "testValue"
            };
            tagHelper.Process(context, output);

            // Assert
            Assert.Equal($"btn btn-{tagHelper.BsButtonColor}",
                output.Attributes["class"].Value);
        }
    }
}

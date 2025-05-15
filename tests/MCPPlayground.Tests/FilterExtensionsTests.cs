using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCPPlayground.Extensions;
using MCPPlayground.Models.Filters;

namespace MCPPlayground.Tests;

[TestClass]
public class FilterExtensionsTests
{
    [TestMethod]
    public void FilterExtensions_ToQueryString_ReturnsCorrectQueryString()
    {
        // Arrange
        var filter = new BreweryFilter
        {
            State = "CA",
            Type = "micro"
        };

        // Act
        var queryString = filter.ToQueryString();

        // Assert
        Assert.IsNotNull(queryString);
        Assert.IsTrue(queryString.Contains("by_state=CA"));
        Assert.IsTrue(queryString.Contains("by_type=micro"));
    }
}

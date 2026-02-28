using System.Net;
using FluentAssertions;
using Xunit;

namespace Auth.Wiedersehen.IntegrationTests;

public class SmokeTests : IntegrationTestBase
{
    [Fact]
    public async Task GetEmailAvailable_ReturnsOk_WhenEmailIsValid()
    {
        // Arrange
        var email = "test@example.com";
        var url = $"/api/v1/email/is-available?email={email}";

        // Act
        var response = await Client.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}

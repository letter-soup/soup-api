using Auth.Wiedersehen.IntegrationTests.Extensions;
using Auth.Wiedersehen.IntegrationTests.Fixtures;
using Auth.Wiedersehen.Users;
using Duende.IdentityModel.Client;

namespace Auth.Wiedersehen.IntegrationTests.Token;

public class RevokeTokenIntegrationTests(IntegrationTestFixture fixture) : IntegrationTestBase(fixture)
{
	[Fact]
	public async Task RevokeToken_GivenValidToken_ShouldSucceed()
	{
		// Arrange
		CreateUserRequest user = await RegisterUserAsync();
		TokenResponse tokenResponse = await Client.RequestPasswordTokenAsync(
			TestClientId,
			TestClientSecret,
			user.Email,
			user.Password
		);
		tokenResponse.IsError.Should().BeFalse(tokenResponse.Error);

		// Act
		TokenRevocationResponse revocationResponse = await Client.RevokeTokenAsync(
			TestClientId,
			TestClientSecret,
			tokenResponse.AccessToken!
		);

		// Assert
		revocationResponse.IsError.Should().BeFalse(revocationResponse.Error);
	}
}

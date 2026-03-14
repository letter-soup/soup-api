using Auth.Wiedersehen.IntegrationTests.Extensions;
using Auth.Wiedersehen.IntegrationTests.Fixtures;
using Auth.Wiedersehen.Users;
using Duende.IdentityModel.Client;

namespace Auth.Wiedersehen.IntegrationTests.Token;

public class RefreshTokenIntegrationTests(IntegrationTestFixture fixture) : IntegrationTestBase(fixture)
{
	[Fact]
	public async Task Login_RefreshToken_GivenValidCredentials_ShouldSucceed()
	{
		// Arrange
		CreateUserRequest user = await RegisterUserAsync();

		// Act
		TokenResponse initialTokenResponse = await Client.RequestPasswordTokenAsync(
			TestClientId,
			TestClientSecret,
			user.Email,
			user.Password,
			scope: "openid profile soup offline_access"
		);

		// Assert
		initialTokenResponse.IsError.Should().BeFalse(initialTokenResponse.Error);
		initialTokenResponse.AccessToken.Should().NotBeNullOrWhiteSpace();
		initialTokenResponse.RefreshToken.Should().NotBeNullOrWhiteSpace();

		// Use the refresh token
		TokenResponse refreshedTokenResponse = await Client.RequestRefreshTokenAsync(
			TestClientId,
			TestClientSecret,
			initialTokenResponse.RefreshToken!
		);

		refreshedTokenResponse.IsError.Should().BeFalse(refreshedTokenResponse.Error);
		refreshedTokenResponse.AccessToken.Should().NotBeNullOrWhiteSpace();
		refreshedTokenResponse.RefreshToken.Should().NotBeNullOrWhiteSpace();
		refreshedTokenResponse.AccessToken.Should().NotBe(initialTokenResponse.AccessToken);
	}


	[Fact]
	public async Task RefreshToken_GivenInvalidToken_ShouldFail()
	{
		// Arrange
		var invalidRefreshToken = Fixture.Create<string>();

		// Act
		TokenResponse tokenResponse = await Client.RequestRefreshTokenAsync(
			TestClientId,
			TestClientSecret,
			invalidRefreshToken
		);

		// Assert
		tokenResponse.IsError.Should().BeTrue();
		tokenResponse.Error.Should().Be("invalid_grant");
	}
}

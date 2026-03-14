using System.Net;
using Auth.Wiedersehen.IntegrationTests.Extensions;
using Auth.Wiedersehen.Users;
using Duende.IdentityModel.Client;

namespace Auth.Wiedersehen.IntegrationTests;

public class AuthIntegrationTests : IntegrationTestBase
{
	[Fact]
	public async Task RegisterLoginLogoutFlow_ShouldSucceed()
	{
		// 1. User registration
		var email = Fixture.CreateEmail();
		var password = Fixture.CreatePassword();
		var registrationRequest = new CreateUserRequest(email, password, true);

		HttpResponseMessage registrationResponse = await Client.CreateUserAsync(registrationRequest);
		registrationResponse.StatusCode.Should().Be(HttpStatusCode.Created);

		CreateUserResponse? registrationResult = await registrationResponse.As<CreateUserResponse>();
		registrationResult.Should().NotBeNull();
		registrationResult.UserId.Should().NotBeNullOrWhiteSpace();

		// 2. Login using email and password
		TokenResponse tokenResponse = await Client.RequestPasswordTokenAsync(
			TestClientId,
			TestClientSecret,
			email,
			password
		);

		tokenResponse.IsError.Should().BeFalse(tokenResponse.Error);
		tokenResponse.AccessToken.Should().NotBeNullOrWhiteSpace();
		// tokenResponse.IdentityToken.Should().NotBeNullOrWhiteSpace(); // ResourceOwnerPassword might not return id_token depending on configuration

		// 3. Log out (Revoke token)
		TokenRevocationResponse revocationResponse = await Client.RevokeTokenAsync(
			TestClientId,
			TestClientSecret,
			tokenResponse.AccessToken!
		);

		revocationResponse.IsError.Should().BeFalse(revocationResponse.Error);
	}

	[Fact]
	public async Task RefreshTokenFlow_ShouldSucceed()
	{
		// 1. User registration
		var email = Fixture.CreateEmail();
		var password = Fixture.CreatePassword();
		var registrationRequest = new CreateUserRequest(email, password, true);

		await Client.CreateUserAsync(registrationRequest, HttpClientMode.VerifySuccess);

		// 2. Login to get initial tokens (request offline_access scope for refresh token)
		TokenResponse initialTokenResponse = await Client.RequestPasswordTokenAsync(
			TestClientId,
			TestClientSecret,
			email,
			password,
			scope: "openid profile soup offline_access"
		);

		initialTokenResponse.IsError.Should().BeFalse(initialTokenResponse.Error);
		initialTokenResponse.AccessToken.Should().NotBeNullOrWhiteSpace();
		initialTokenResponse.RefreshToken.Should().NotBeNullOrWhiteSpace();

		// 3. Use refresh token to get a new access token
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
}

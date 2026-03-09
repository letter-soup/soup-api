using System.Net.Http.Json;
using Auth.Wiedersehen.Users;

namespace Auth.Wiedersehen.IntegrationTests.Extensions;

public static class HttpClientExtensions
{
	private static HttpResponseMessage VerifyResponse(HttpResponseMessage response, HttpClientMode clientCallMode)
	{
		switch (clientCallMode)
		{
			case HttpClientMode.VerifySuccess:
				response.IsSuccessStatusCode.Should().BeTrue();
				break;
			case HttpClientMode.VerifyFailure:
				response.IsSuccessStatusCode.Should().BeFalse();
				break;
			case HttpClientMode.SkipVerification:
			default:
				break;
		}

		return response;
	}

	extension(HttpClient client)
	{
		public async Task<HttpResponseMessage> CreateUserAsync(
			CreateUserRequest request,
			HttpClientMode mode = HttpClientMode.SkipVerification
		)
		{
			return VerifyResponse(await client.PostAsJsonAsync("/api/v1/user", request), mode);
		}

		public async Task<HttpResponseMessage> IsEmailAvailableAsync(
			string email,
			HttpClientMode mode = HttpClientMode.SkipVerification
		)
		{
			return VerifyResponse(await client.GetAsync($"/api/v1/email/is-available?email={email}"), mode);
		}
	}

	extension(HttpResponseMessage message)
	{
		public async Task<T?> As<T>()
		{
			return await message.Content.ReadFromJsonAsync<T>();
		}
	}
}

using Microsoft.AspNetCore.Identity;

namespace Auth.Wiedersehen.Extensions;

internal static class IdentityResultExtensions
{
	public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(this IdentityResult result)
	{
		return result.Errors.Select(ToKeyValuePair);
	}

	private static KeyValuePair<string, string> ToKeyValuePair(IdentityError failure)
	{
		return new KeyValuePair<string, string>(failure.Code, failure.Description);
	}
}

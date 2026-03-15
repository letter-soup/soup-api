namespace Soup.Api.AppSettings;

public static class DefaultConfiguration
{
	public static IEnumerable<KeyValuePair<string, string>> Get() =>
	[
		new KeyValuePair<string, string>("Auth:Jwt:ValidateAudience", "false"),
		new KeyValuePair<string, string>("Auth:Jwt:RequireHttpsMetadata", "false"),
	];
}

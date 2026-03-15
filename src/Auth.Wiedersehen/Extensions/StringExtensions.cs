namespace Auth.Wiedersehen.Extensions;

internal static class StringExtensions
{
	public static string Normalize(this string str)
	{
		return str.ToLower();
	}
}

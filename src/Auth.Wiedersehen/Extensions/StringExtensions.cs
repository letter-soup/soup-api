namespace Auth.Wiedersehen.Extensions;

public static class StringExtensions
{
    public static string Normalize(this string str)
    {
        return str.ToLower();
    }
}
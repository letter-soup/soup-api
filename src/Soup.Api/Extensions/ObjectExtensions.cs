using Soup.Api.Exceptions;

namespace Soup.Api.Extensions;

public static class ObjectExtensions
{
    public static T Required<T>(this T? argument, string? paramName)
    {
        return argument ?? throw new ValueRequiredException(paramName);
    }
}
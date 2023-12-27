namespace Soup.Api.Exceptions;

public abstract class SoupException(string? message) : ApplicationException(message);
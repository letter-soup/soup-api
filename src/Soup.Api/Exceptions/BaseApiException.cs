namespace Soup.Api.Exceptions;

public abstract class BaseApiException(string? message) : ApplicationException(message);
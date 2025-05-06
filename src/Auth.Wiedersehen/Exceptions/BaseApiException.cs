namespace Auth.Wiedersehen.Exceptions;

public abstract class BaseApiException(string? message) : ApplicationException(message);
namespace Auth.Wiedersehen.Exceptions;

internal class BaseApiException : ApplicationException
{
    protected BaseApiException()
    {
    }

    public BaseApiException(string message) : base(message)
    {
    }
}
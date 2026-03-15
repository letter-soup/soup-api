namespace Auth.Wiedersehen.Exceptions;

internal class HttpResponseException(
	IEnumerable<KeyValuePair<string, string>> errors,
	int statusCode = StatusCodes.Status400BadRequest
) : BaseApiException
{
	public int StatusCode { get; } = statusCode;
	public IEnumerable<KeyValuePair<string, string>>? Errors { get; } = errors;
}

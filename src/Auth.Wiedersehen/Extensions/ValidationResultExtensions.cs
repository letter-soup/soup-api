using FluentValidation.Results;

namespace Auth.Wiedersehen.Extensions;

internal static class ValidationResultExtensions
{
	public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(this ValidationResult result)
	{
		return result.Errors.Select(ToKeyValuePair);
	}

	private static KeyValuePair<string, string> ToKeyValuePair(ValidationFailure failure)
	{
		return new KeyValuePair<string, string>(failure.PropertyName, failure.ErrorMessage);
	}
}

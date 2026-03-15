namespace Auth.Wiedersehen.Exceptions;

public record ErrorDetails(int StatusCode, IEnumerable<KeyValuePair<string, string>>? Errors);

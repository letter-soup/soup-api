namespace Auth.Wiedersehen.Controllers.Models;

public record CreateUserRequest(string Email, string Password, bool TermsAccepted);
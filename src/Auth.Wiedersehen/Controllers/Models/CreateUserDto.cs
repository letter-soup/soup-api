using FluentValidation;

namespace Auth.Wiedersehen.Controllers.Models;

public record CreateUserRequest(string Email, string Password, bool TermsAccepted);
public record CreateUserResponse(string UserId);

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator(IConfiguration configuration)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(configuration.GetValue<int>("Password:MinLength"))
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        RuleFor(x => x.TermsAccepted)
            .Equal(true)
            .WithMessage("You must accept the terms and conditions");
    }
}
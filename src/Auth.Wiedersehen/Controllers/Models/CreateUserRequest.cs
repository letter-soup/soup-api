using FluentValidation;

namespace Auth.Wiedersehen.Controllers.Models;

public record CreateUserRequest(string Email, string Password, bool TermsAccepted);

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Password)
            .NotEmpty();
        RuleFor(x => x.TermsAccepted)
            .Equal(true)
            .WithMessage("You must accept the terms and conditions");
    }
}
using Auth.Wiedersehen.Controllers.Services;
using FluentValidation;

namespace Auth.Wiedersehen.Controllers.Models;

public record CreateUserRequest(string Email, string Password, bool TermsAccepted);
public record CreateUserResponse(string UserId);

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator(IConfiguration configuration, ILocalizer<CreateUserRequestValidator> localizer)
    {
        var passwordMinLength = configuration.GetValue<int>("Password:MinLength");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(localizer.GetString("Email:Missing"))
            .EmailAddress()
            .WithMessage(localizer.GetString("Email:Invalid"));
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(localizer.GetString("Password:Missing"))
            .MinimumLength(passwordMinLength)
            .WithMessage(localizer.GetString("Password:TooShort", passwordMinLength))
            .Matches("[A-Z]")
            .WithMessage(localizer.GetString("Password:UppercaseMissing"))
            .Matches("[a-z]")
            .WithMessage(localizer.GetString("Password:LowercaseMissing"))
            .Matches("[0-9]")
            .WithMessage(localizer.GetString("Password:DigitMissing"))
            .Matches("[^a-zA-Z0-9]")
            .WithMessage(localizer.GetString("Password:SpecialMissing"));
        RuleFor(x => x.TermsAccepted)
            .Equal(true)
            .WithMessage(localizer.GetString("Terms:NotAccepted"));
    }
}
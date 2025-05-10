using FluentValidation;

namespace Auth.Wiedersehen.Controllers.Models;

public record EmailAvailableRequest(string Email);

public class EmailAvailableRequestValidator : AbstractValidator<EmailAvailableRequest>
{
    public EmailAvailableRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
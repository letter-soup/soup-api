using Auth.Wiedersehen.Controllers.Services;
using FluentValidation;

namespace Auth.Wiedersehen.Controllers.Models;

public record EmailAvailableRequest(string Email);

public class EmailAvailableRequestValidator : AbstractValidator<EmailAvailableRequest>
{
    public EmailAvailableRequestValidator(ILocalizer<EmailAvailableRequestValidator> localizer)
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(localizer.GetString("Email:Missing"))
            .EmailAddress().WithMessage(localizer.GetString("Email:Invalid"));
    }
}
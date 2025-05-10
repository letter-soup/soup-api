using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.Controllers.Services;
using Auth.Wiedersehen.Exceptions;
using Auth.Wiedersehen.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Auth.Wiedersehen.Controllers;

[ApiController]
[Route("api/v1/email")]
public class EmailController(IEmailService emailService) : Controller
{
    private readonly IEmailService _emailService = emailService.Required(nameof(emailService));

    [HttpGet("is-available")]
    public async Task<IActionResult> EmailAvailableAsync(
        [FromServices] IValidator<EmailAvailableRequest> validator,
        [FromQuery] EmailAvailableRequest request
    )
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new HttpResponseException(validationResult.ToKeyValuePairs());
        }

        var emailAvailable = await _emailService.IsEmailAvailableAsync(request.Email);

        return emailAvailable ? Ok() : Conflict();
    }
}
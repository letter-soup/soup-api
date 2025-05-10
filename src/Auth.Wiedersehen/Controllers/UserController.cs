using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.Controllers.Services;
using Auth.Wiedersehen.Exceptions;
using Auth.Wiedersehen.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Wiedersehen.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService.Required(nameof(userService));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorDetails>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateUserAsync(
        [FromServices] IValidator<CreateUserRequest> validator,
        [FromBody] CreateUserRequest request
    )
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new HttpResponseException(validationResult.ToKeyValuePairs());
        }

        await _userService.CreateAsync(request);

        return Created();
    }
}
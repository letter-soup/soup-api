using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.Controllers.Services;
using Auth.Wiedersehen.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Wiedersehen.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController(
    IUserService userService
) : Controller
{
    private readonly IUserService _userService = userService.Required(nameof(userService));

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(
        [FromServices] IValidator<CreateUserRequest> validator,
        [FromBody] CreateUserRequest request
    )
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return validationResult.ToBadRequest();
        }

        var result = await _userService.CreateAsync(request);
        return Created();
    }
}
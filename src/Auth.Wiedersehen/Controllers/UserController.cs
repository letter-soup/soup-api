using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.Controllers.Services;
using Auth.Wiedersehen.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Wiedersehen.Controllers;

[ApiController]
[Route("/api/v1/user")]
public class UserController(
    IUserService userService
) : Controller
{
    private readonly IUserService _userService = userService.Required(nameof(userService));

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
    {
        var result = await _userService.CreateAsync(request);
        return Ok(result);
    }
}
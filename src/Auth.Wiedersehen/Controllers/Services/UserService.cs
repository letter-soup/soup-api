using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.Database.Models;
using Auth.Wiedersehen.Exceptions;
using Auth.Wiedersehen.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Auth.Wiedersehen.Controllers.Services;

internal sealed class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager.Required(nameof(userManager));

    public async Task<CreateUserResponse> CreateAsync(CreateUserRequest request)
    {
        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            TermsAcceptanceTime = DateTime.UtcNow,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new HttpResponseException(result.ToKeyValuePairs(), StatusCodes.Status409Conflict);
        }

        return new CreateUserResponse(user.Id);
    }
}
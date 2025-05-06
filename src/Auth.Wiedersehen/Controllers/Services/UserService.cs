using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.Database.Models;
using Auth.Wiedersehen.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Auth.Wiedersehen.Controllers.Services;

internal sealed class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager.Required(nameof(userManager));

    public async Task<CreateUserResult> CreateAsync(CreateUserRequest request)
    {
        var result = await _userManager.CreateAsync(
            new ApplicationUser
            {
                Email = request.Email,
                TermsAcceptanceTime = DateTime.UtcNow,
            },
            request.Password
        );

        if (!result.Succeeded)
        {
            throw new Exception("Failed to create user");
        }

        return new CreateUserResult();
    }
}
using Auth.Wiedersehen.Extensions;
using Auth.Wiedersehen.Users;
using Microsoft.AspNetCore.Identity;

namespace Auth.Wiedersehen.Emails;

internal sealed class EmailService(UserManager<ApplicationUser> userManager) : IEmailService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager.Required(nameof(userManager));

    public async Task<bool> IsEmailAvailableAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) is null;
    }
}
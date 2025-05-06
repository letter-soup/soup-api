using Auth.Wiedersehen.Controllers.Models;

namespace Auth.Wiedersehen.Controllers.Services;

internal sealed class UserService : IUserService
{
    public Task<CreateUserResult> CreateAsync(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }
}
using Auth.Wiedersehen.Controllers.Models;

namespace Auth.Wiedersehen.Controllers.Services;

public interface IUserService
{
    Task<CreateUserResult> CreateAsync(CreateUserRequest request);
}
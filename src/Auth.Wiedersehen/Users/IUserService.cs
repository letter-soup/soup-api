namespace Auth.Wiedersehen.Users;

public interface IUserService
{
	Task<CreateUserResponse> CreateAsync(CreateUserRequest request);
}

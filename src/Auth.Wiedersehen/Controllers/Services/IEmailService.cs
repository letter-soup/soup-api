namespace Auth.Wiedersehen.Controllers.Services;

public interface IEmailService
{
    Task<bool> IsEmailAvailableAsync(string email);
}
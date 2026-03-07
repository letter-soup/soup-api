namespace Auth.Wiedersehen.Emails;

public interface IEmailService
{
    Task<bool> IsEmailAvailableAsync(string email);
}
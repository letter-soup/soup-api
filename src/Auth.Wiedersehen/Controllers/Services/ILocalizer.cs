namespace Auth.Wiedersehen.Controllers.Services;

public interface ILocalizer<T>
{
    string GetString(string key);
    string GetString(string key, params object[] args);
}
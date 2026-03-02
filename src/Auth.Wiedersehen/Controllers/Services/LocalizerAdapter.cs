using Microsoft.Extensions.Localization;

namespace Auth.Wiedersehen.Controllers.Services;

internal sealed class LocalizerAdapter<T>(IStringLocalizer<T> localizer) : ILocalizer<T>
{
    public string GetString(string key)
    {
        return localizer.GetString(key);
    }

    public string GetString(string key, params object[] args)
    {
        return localizer.GetString(key, args);
    }
}
using Auth.Wiedersehen.Resources;
using Microsoft.Extensions.Localization;

namespace Auth.Wiedersehen.Localization;

internal sealed class LocalizerAdapter(IStringLocalizer<SharedResource> localizer) : ILocalizer
{
    public string this[string name] => localizer[name];
    public string this[string name, params object[] arguments] => localizer[name, arguments];
}
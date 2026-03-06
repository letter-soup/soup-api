namespace Auth.Wiedersehen.Localization;

public interface ILocalizer
{
    string this[string name] { get; }
    string this[string name, params object[] arguments] { get; }
}
namespace Auth.Wiedersehen.UnitTests.Extensions;

[Flags]
public enum PasswordConfig
{
	None = 0,
	LowerCase = 1,
	UpperCase = 2,
	Digits = 4,
	Special = 8,
	All = LowerCase | UpperCase | Digits | Special,
}

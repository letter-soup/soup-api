namespace Auth.Wiedersehen.Configuration;

internal struct ConfigurationKey
{
	public struct Password
	{
		public const string MinLength = "Password:MinLength";
	}

	public struct ConnectionString
	{
		public const string ApplicationDb = "ApplicationDB";
		public const string ConfigurationDb = "ConfigurationDB";
		public const string PersistentGrandDb = "PersistentGrandDB";
	}
}

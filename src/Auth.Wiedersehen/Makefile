bundle_migrations:
	dotnet ef migrations bundle -c ConfigurationDbContext --self-contained -r linux-x64 -o configuration_db
	dotnet ef migrations bundle -c PersistedGrantDbContext --self-contained -r linux-x64 -o persistent_grant_db
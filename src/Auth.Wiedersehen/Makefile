migrate_configuration:
	dotnet ef migrations bundle -c ConfigurationDbContext --self-contained -r linux-x64 -o configuration_db
	./configuration_db --connection="Host=localhost;Database=configuration_db;Username=postgres;Password=Qwert1234_;"
	rm configuration_db

migrate_persistent_grant:
	dotnet ef migrations bundle -c PersistedGrantDbContext --self-contained -r linux-x64 -o persistent_grant_db
	./persistent_grant_db --connection="Host=localhost;Database=persisted_grant_db;Username=postgres;Password=Qwert1234_;"
	rm persistent_grant_db

migrate_application:
	dotnet ef migrations bundle -c ApplicationDbContext --self-contained -r linux-x64 -o application_db
	./application_db --connection="Host=localhost;Database=auth_wiedersehen;Username=postgres;Password=Qwert1234_;"
	rm application_db

full_migrations:
	make migrate_configuration
	make migrate_persistent_grant
	make migrate_application

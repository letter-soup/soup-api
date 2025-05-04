bundle_migrations:
	dotnet ef migrations bundle -c ConfigurationDbContext --self-contained -r linux-x64 -o configuration_db
	dotnet ef migrations bundle -c PersistedGrantDbContext --self-contained -r linux-x64 -o persistent_grant_db
	dotnet ef migrations bundle -c AppicationDbContext --self-contained -r linux-x64 -o application_db

apply_migrations:
	./configuration_db --connection="Host=localhost;Database=configuration_db;Username=postgres;Password=Qwert1234_;"
	./persistent_grant_db --connection="Host=localhost;Database=persisted_grant_db;Username=postgres;Password=Qwert1234_;"
	./application_db --connection="Host=localhost;Database=auth_wiedersehen;Username=postgres;Password=Qwert1234_;"

remove_bundles:
	rm configuration_db
	rm persistent_grant_db
	rm application_db

full_migrations:
	make bundle_migrations
	make apply_migrations
	make remove_bundles

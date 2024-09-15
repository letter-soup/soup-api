-- up
if dingo.exists_table('ClientPostLogoutRedirectUris', 'dbo') = 0
begin
    create table dbo.ClientPostLogoutRedirectUris (
        Id int not null identity,
        PostLogoutRedirectUri nvarchar(400) not null,
        ClientId int not null,
        constraint PK_ClientPostLogoutRedirectUris primary key (Id),
        constraint FK_ClientPostLogoutRedirectUris_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientPostLogoutRedirectUris', 'dbo') = 1
begin
    drop table dbo.ClientPostLogoutRedirectUris
end

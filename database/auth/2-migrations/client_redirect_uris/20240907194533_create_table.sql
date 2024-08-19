-- up
if dingo.exists_table('ClientRedirectUris', 'dbo') = 0
begin
    create table dbo.ClientRedirectUris (
        Id int not null identity,
        RedirectUri nvarchar(400) not null,
        ClientId int not null,
        constraint PK_ClientRedirectUris primary key (Id),
        constraint FK_ClientRedirectUris_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientRedirectUris', 'dbo') = 1
begin
    drop table dbo.ClientRedirectUris;
end

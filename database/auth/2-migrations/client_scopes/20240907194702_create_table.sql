-- up
if dingo.exists_table('ClientScopes', 'dbo') = 0
begin
    create table dbo.ClientScopes (
        Id int not null identity,
        Scope nvarchar(200) not null,
        ClientId int not null,
        constraint PK_ClientScopes primary key (Id),
        constraint FK_ClientScopes_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientScopes', 'dbo') = 1
begin
    drop table dbo.ClientScopes;
end

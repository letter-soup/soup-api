-- up
if dingo.exists_table('ClientSecrets', 'dbo') = 0
begin
    create table dbo.ClientSecrets (
        Id int not null identity,
        ClientId int not null,
        Description nvarchar(2000) null,
        Value nvarchar(4000) not null,
        Expiration datetime2 null,
        Type nvarchar(250) not null,
        Created datetime2 not null,
        constraint PK_ClientSecrets primary key (Id),
        constraint FK_ClientSecrets_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientSecrets', 'dbo') = 1
begin
    drop table dbo.ClientSecrets;
end

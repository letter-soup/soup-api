-- up
if dingo.exists_table('ClientGrantTypes', 'dbo') = 0
begin
    create table dbo.ClientGrantTypes (
        Id int not null identity,
        GrantType nvarchar(250) not null,
        ClientId int not null,
        constraint PK_ClientGrantTypes primary key (Id),
        constraint FK_ClientGrantTypes_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientGrantTypes', 'dbo') = 1
begin
    drop table dbo.ClientGrantTypes
end

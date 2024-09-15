-- up
if dingo.exists_table('ClientCorsOrigins', 'dbo') = 0
begin
    create table dbo.ClientCorsOrigins (
        Id int not null identity,
        Origin nvarchar(150) not null,
        ClientId int not null,
        constraint PK_ClientCorsOrigins primary key (Id),
        constraint FK_ClientCorsOrigins_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientCorsOrigins', 'dbo') = 1
begin
    drop table dbo.ClientCorsOrigins
end

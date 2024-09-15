-- up
if dingo.exists_table('ClientClaims', 'dbo') = 0
begin
    create table dbo.ClientClaims (
        Id int not null identity,
        Type nvarchar(250) not null,
        Value nvarchar(250) not null,
        ClientId int not null,
        constraint PK_ClientClaims primary key (Id),
        constraint FK_ClientClaims_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientClaims', 'dbo') = 1
begin
    drop table dbo.ClientClaims
end

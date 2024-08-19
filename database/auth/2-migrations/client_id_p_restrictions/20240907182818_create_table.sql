-- up
if dingo.exists_table('ClientIdPRestrictions', 'dbo') = 0
begin
    create table dbo.ClientIdPRestrictions (
        Id int not null identity,
        Provider nvarchar(200) not null,
        ClientId int not null,
        constraint PK_ClientIdPRestrictions primary key (Id),
        constraint FK_ClientIdPRestrictions_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientIdPRestrictions', 'dbo') = 1
begin
    drop table dbo.ClientIdPRestrictions;
end

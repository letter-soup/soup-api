-- up
if dingo.exists_table('ClientProperties', 'dbo') = 0
begin
    create table dbo.ClientProperties (
        Id int not null identity,
        ClientId int not null,
        [Key] nvarchar(250) not null,
        Value nvarchar(2000) not null,
        constraint PK_ClientProperties primary key (Id),
        constraint FK_ClientProperties_Clients_ClientId foreign key (ClientId) references dbo.Clients (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ClientProperties', 'dbo') = 1
begin
    drop table dbo.ClientProperties
end

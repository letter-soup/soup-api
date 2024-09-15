-- up
if dingo.exists_table('PersistedGrants', 'dbo') = 0
begin
    create table PersistedGrants (
        Id bigint not null identity,
        [Key] nvarchar(200) null,
        Type nvarchar(50) not null,
        SubjectId nvarchar(200) null,
        SessionId nvarchar(100) null,
        ClientId nvarchar(200) not null,
        Description nvarchar(200) null,
        CreationTime datetime2 not null,
        Expiration datetime2 null,
        ConsumedTime datetime2 null,
        Data nvarchar(max) not null,
        constraint PK_PersistedGrants primary key (Id)
    )
end

-- down
if dingo.exists_table('PersistedGrants', 'dbo') = 1
begin
    drop table dbo.PersistedGrants
end

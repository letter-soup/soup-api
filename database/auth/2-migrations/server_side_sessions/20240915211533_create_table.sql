-- up
if dingo.exists_table('ServerSideSessions', 'dbo') = 0
begin
    create table ServerSideSessions (
        Id bigint not null identity,
        [Key] nvarchar(100) not null,
        Scheme nvarchar(100) not null,
        SubjectId nvarchar(100) not null,
        SessionId nvarchar(100) null,
        DisplayName nvarchar(100) null,
        Created datetime2 not null,
        Renewed datetime2 not null,
        Expires datetime2 null,
        Data nvarchar(max) not null,
        constraint PK_ServerSideSessions primary key (Id)
    )
end

-- down
if dingo.exists_table('ServerSideSessions', 'dbo') = 1
begin
    drop table dbo.ServerSideSessions
end

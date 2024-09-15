-- up
if dingo.exists_table('DeviceCodes', 'dbo') = 0
begin
    create table DeviceCodes (
        UserCode nvarchar(200) not null,
        DeviceCode nvarchar(200) not null,
        SubjectId nvarchar(200) null,
        SessionId nvarchar(100) null,
        ClientId nvarchar(200) not null,
        Description nvarchar(200) null,
        CreationTime datetime2 not null,
        Expiration datetime2 not null,
        Data nvarchar(max) not null,
        constraint PK_DeviceCodes primary key (UserCode)
    )
end

-- down
if dingo.exists_table('DeviceCodes', 'dbo') = 1
begin
    drop table dbo.DeviceCodes
end

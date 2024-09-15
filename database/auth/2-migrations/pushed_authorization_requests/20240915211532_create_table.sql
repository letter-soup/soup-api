-- up
if dingo.exists_table('PushedAuthorizationRequests', 'dbo') = 0
begin
    create table PushedAuthorizationRequests (
        Id bigint not null identity,
        ReferenceValueHash nvarchar(64) not null,
        ExpiresAtUtc datetime2 not null,
        Parameters nvarchar(max) not null,
        constraint PK_PushedAuthorizationRequests primary key (Id)
    )
end

-- down
if dingo.exists_table('PushedAuthorizationRequests', 'dbo') = 1
begin
    drop table dbo.PushedAuthorizationRequests
end

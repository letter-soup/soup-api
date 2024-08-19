-- up
if dingo.exists_table('ApiScopes', 'dbo') = 0
begin
    create table dbo.ApiScopes (
        Id int not null identity,
        Enabled bit not null,
        Name nvarchar(200) not null,
        DisplayName nvarchar(200) null,
        Description nvarchar(1000) null,
        Required bit not null,
        Emphasize bit not null,
        ShowInDiscoveryDocument bit not null,
        Created datetime2 not null,
        Updated datetime2 null,
        LastAccessed datetime2 null,
        NonEditable bit not null,
        constraint PK_ApiScopes primary key (Id)
    )
end

-- down
if dingo.exists_table('ApiScopes', 'dbo') = 1
begin
    drop table dbo.ApiScopes;
end

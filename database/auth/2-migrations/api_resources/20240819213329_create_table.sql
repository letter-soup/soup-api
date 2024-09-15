-- up
if dingo.exists_table('ApiResources', 'dbo') = 0
begin
    create table dbo.ApiResources (
        Id int not null identity,
        Enabled bit not null,
        Name nvarchar(200) not null,
        DisplayName nvarchar(200) null,
        Description nvarchar(1000) null,
        AllowedAccessTokenSigningAlgorithms nvarchar(100) NULL,
        ShowInDiscoveryDocument bit not null,
        RequireResourceIndicator bit not null,
        Created datetime2 not null,
        Updated datetime2 null,
        LastAccessed datetime2 null,
        NonEditable bit not null,
        constraint PK_ApiResources primary key (Id)
    )
end

-- down
if dingo.exists_table('ApiResources', 'dbo') = 1
begin
    drop table dbo.ApiResources
end

-- up
if dingo.exists_table('IdentityResources', 'dbo') = 0
begin
    create table dbo.IdentityResources (
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
        NonEditable bit not null,
        constraint PK_IdentityResources primary key (Id)
    )
end

-- down
if dingo.exists_table('IdentityResources', 'dbo') = 1
begin
    drop table dbo.IdentityResources
end

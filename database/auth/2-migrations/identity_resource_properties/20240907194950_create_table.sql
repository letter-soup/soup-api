-- up
if dingo.exists_table('IdentityResourceProperties', 'dbo') = 0
begin
    create table dbo.IdentityResourceProperties (
        Id int not null identity,
        IdentityResourceId int not null,
        [Key] nvarchar(250) not null,
        Value nvarchar(2000) not null,
        constraint PK_IdentityResourceProperties primary key (Id),
        constraint FK_IdentityResourceProperties_IdentityResources_IdentityResourceId foreign key (IdentityResourceId) references dbo.IdentityResources (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('IdentityResourceProperties', 'dbo') = 1
begin
    drop table dbo.IdentityResourceProperties;
end

-- up
if dingo.exists_table('IdentityResourceClaims', 'dbo') = 0
begin
    create table dbo.IdentityResourceClaims (
        Id int not null identity,
        IdentityResourceId int not null,
        Type nvarchar(200) not null,
        constraint PK_IdentityResourceClaims primary key (Id),
        constraint FK_IdentityResourceClaims_IdentityResources_IdentityResourceId foreign key (IdentityResourceId) references dbo.IdentityResources (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('IdentityResourceClaims', 'dbo') = 1
begin
    drop table dbo.IdentityResourceClaims;
end

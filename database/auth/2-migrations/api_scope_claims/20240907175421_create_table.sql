-- up
if dingo.exists_table('ApiScopeClaims', 'dbo') = 0
begin
    create table dbo.ApiScopeClaims (
        Id int not null identity,
        ScopeId int not null,
        Type nvarchar(200) not null,
        constraint PK_ApiScopeClaims primary key (Id),
        constraint FK_ApiScopeClaims_ApiScopes_ScopeId foreign key (ScopeId) references dbo.ApiScopes (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ApiScopeClaims', 'dbo') = 1
begin
    drop table dbo.ApiScopeClaims
end

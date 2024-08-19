-- up
if dingo.exists_table('ApiScopeProperties', 'dbo') = 0
begin
    create table dbo.ApiScopeProperties (
        Id int not null identity,
        ScopeId int not null,
        [Key] nvarchar(250) not null,
        Value nvarchar(2000) not null,
        constraint PK_ApiScopeProperties primary key (Id),
        constraint FK_ApiScopeProperties_ApiScopes_ScopeId foreign key (ScopeId) references dbo.ApiScopes (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ApiScopeProperties', 'dbo') = 1
begin
    drop table dbo.ApiScopeProperties;
end

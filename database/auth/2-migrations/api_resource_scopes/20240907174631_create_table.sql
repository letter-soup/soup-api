-- up
if dingo.exists_table('ApiResourceScopes', 'dbo') = 0
begin
    create table dbo.ApiResourceScopes (
        Id int not null identity,
        Scope nvarchar(200) not null,
        ApiResourceId int not null,
        constraint PK_ApiResourceScopes primary key (Id),
        constraint FK_ApiResourceScopes_ApiResources_ApiResourceId foreign key (ApiResourceId) references dbo.ApiResources (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ApiResourceScopes', 'dbo') = 1
begin
    drop table dbo.ApiResourceScopes
end

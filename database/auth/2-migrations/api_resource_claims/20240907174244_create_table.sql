-- up
if dingo.exists_table('ApiResourceClaims', 'dbo') = 0
begin
    create table dbo.ApiResourceClaims (
        Id int not null identity,
        ApiResourceId int not null,
        Type nvarchar(200) not null,
        constraint PK_ApiResourceClaims primary key (Id),
        constraint FK_ApiResourceClaims_ApiResources_ApiResourceId foreign key (ApiResourceId) references dbo.ApiResources (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ApiResourceClaims', 'dbo') = 1
begin
    drop table dbo.ApiResourceClaims
end

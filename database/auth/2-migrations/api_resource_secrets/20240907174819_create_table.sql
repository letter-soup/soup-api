-- up
if dingo.exists_table('ApiResourceSecrets', 'dbo') = 0
begin
    create table dbo.ApiResourceSecrets (
        Id int not null identity,
        ApiResourceId int not null,
        Description nvarchar(1000) null,
        Value nvarchar(4000) not null,
        Expiration datetime2 null,
        Type nvarchar(250) not null,
        Created datetime2 not null,
        constraint PK_ApiResourceSecrets primary key (Id),
        constraint FK_ApiResourceSecrets_ApiResources_ApiResourceId foreign key (ApiResourceId) references dbo.ApiResources (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ApiResourceSecrets', 'dbo') = 1
begin
    drop table dbo.ApiResourceSecrets
end

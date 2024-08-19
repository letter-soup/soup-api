-- up
if dingo.exists_table('ApiResourceProperties', 'dbo') = 0
begin
    create table dbo.ApiResourceProperties (
            Id int not null identity,
            ApiResourceId int not null,
            [Key] nvarchar(250) not null,
            Value nvarchar(2000) not null,
            constraint PK_ApiResourceProperties primary key (Id),
            constraint FK_ApiResourceProperties_ApiResources_ApiResourceId foreign key (ApiResourceId) references dbo.ApiResources (Id) on delete cascade
    )
end

-- down
if dingo.exists_table('ApiResourceProperties', 'dbo') = 1
begin
    drop table dbo.ApiResourceProperties;
end

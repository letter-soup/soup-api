-- up
if dingo.exists_table('IdentityProviders', 'dbo') = 0
begin
    create table dbo.IdentityProviders (
        Id int not null identity,
        Scheme nvarchar(200) not null,
        DisplayName nvarchar(200) null,
        Enabled bit not null,
        Type nvarchar(20) not null,
        Properties nvarchar(max) null,
        Created datetime2 not null,
        Updated datetime2 null,
        LastAccessed datetime2 null,
        NonEditable bit not null,
        constraint PK_IdentityProviders primary key (Id)
    )
end

-- down
if dingo.exists_table('IdentityProviders', 'dbo') = 1
begin
    drop table dbo.IdentityProviders
end

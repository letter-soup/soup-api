-- up
if dingo.exists_table('Keys', 'dbo') = 0
begin
    create table Keys (
        Id nvarchar(450) not null,
        Version int not null,
        Created datetime2 not null,
        [Use] nvarchar(450) null,
        Algorithm nvarchar(100) not null,
        IsX509Certificate bit not null,
        DataProtected bit not null,
        Data nvarchar(max) not null,
        constraint PK_Keys primary key (Id)
    )
end

-- down
if dingo.exists_table('Keys', 'dbo') = 1
begin
    drop table dbo.Keys
end

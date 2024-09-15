-- up
if dingo.exists_table('Keys', 'dbo') = 1 and
   dingo.exists_index('Keys', 'IX_Keys_Use', 'dbo') = 0
begin
    create index IX_Keys_Use on dbo.Keys ([Use])
end

-- down
if dingo.exists_index('Keys', 'IX_Keys_Use', 'dbo') = 1
begin
    drop index IX_Keys_Use on dbo.Keys
end
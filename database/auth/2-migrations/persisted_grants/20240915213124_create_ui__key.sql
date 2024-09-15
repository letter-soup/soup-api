-- up
if dingo.exists_table('PersistedGrants', 'dbo') = 1 and
   dingo.exists_index('PersistedGrants', 'IX_PersistedGrants_Key', 'dbo') = 0
begin
    create unique index IX_PersistedGrants_Key on dbo.PersistedGrants ([Key]) where [Key] is not null
end

-- down
if dingo.exists_index('PersistedGrants', 'IX_PersistedGrants_Key', 'dbo') = 1
begin
    drop index IX_PersistedGrants_Key on dbo.PersistedGrants
end
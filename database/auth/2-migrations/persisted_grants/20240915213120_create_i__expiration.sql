-- up
if dingo.exists_table('PersistedGrants', 'dbo') = 1 and
   dingo.exists_index('PersistedGrants', 'IX_PersistedGrants_Expiration', 'dbo') = 0
begin
    create index IX_PersistedGrants_Expiration on PersistedGrants (Expiration)
end

-- down
if dingo.exists_index('PersistedGrants', 'IX_PersistedGrants_Expiration', 'dbo') = 1
begin
    drop index IX_PersistedGrants_Expiration on dbo.PersistedGrants
end
-- up
if dingo.exists_table('PersistedGrants', 'dbo') = 1 and
   dingo.exists_index('PersistedGrants', 'IX_PersistedGrants_ConsumedTime', 'dbo') = 0
begin
    create index IX_PersistedGrants_ConsumedTime on dbo.PersistedGrants (ConsumedTime)
end

-- down
if dingo.exists_index('PersistedGrants', 'IX_PersistedGrants_ConsumedTime', 'dbo') = 1
begin
    drop index IX_PersistedGrants_ConsumedTime on dbo.PersistedGrants
end
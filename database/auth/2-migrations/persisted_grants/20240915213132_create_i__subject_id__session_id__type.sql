-- up
if dingo.exists_table('PersistedGrants', 'dbo') = 1 and
   dingo.exists_index('PersistedGrants', 'IX_PersistedGrants_SubjectId_SessionId_Type', 'dbo') = 0
begin
    create index IX_PersistedGrants_SubjectId_SessionId_Type on dbo.PersistedGrants (SubjectId, SessionId, [Type])
end

-- down
if dingo.exists_index('PersistedGrants', 'IX_PersistedGrants_SubjectId_SessionId_Type', 'dbo') = 1
begin
    drop index IX_PersistedGrants_SubjectId_SessionId_Type on dbo.PersistedGrants
end
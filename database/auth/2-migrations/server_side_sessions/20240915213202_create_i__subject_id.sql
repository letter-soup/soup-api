-- up
if dingo.exists_table('ServerSideSessions', 'dbo') = 1 and
   dingo.exists_index('ServerSideSessions', 'IX_ServerSideSessions_SubjectId', 'dbo') = 0
begin
    create index IX_ServerSideSessions_SubjectId on dbo.ServerSideSessions (SubjectId)
end

-- down
if dingo.exists_index('ServerSideSessions', 'IX_ServerSideSessions_SubjectId', 'dbo') = 1
begin
    drop index IX_ServerSideSessions_SubjectId on dbo.ServerSideSessions
end
-- up
if dingo.exists_table('ServerSideSessions', 'dbo') = 1 and
   dingo.exists_index('ServerSideSessions', 'IX_ServerSideSessions_SessionId', 'dbo') = 0
begin
    create index IX_ServerSideSessions_SessionId on dbo.ServerSideSessions (SessionId)
end

-- down
if dingo.exists_index('ServerSideSessions', 'IX_ServerSideSessions_SessionId', 'dbo') = 1
begin
    drop index IX_ServerSideSessions_SessionId on dbo.ServerSideSessions
end
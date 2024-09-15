-- up
if dingo.exists_table('ServerSideSessions', 'dbo') = 1 and
   dingo.exists_index('ServerSideSessions', 'IX_ServerSideSessions_Expires', 'dbo') = 0
begin
    create index IX_ServerSideSessions_Expires on ServerSideSessions (Expires)
end

-- down
if dingo.exists_index('ServerSideSessions', 'IX_ServerSideSessions_Expires', 'dbo') = 1
begin
    drop index IX_ServerSideSessions_Expires on dbo.ServerSideSessions
end
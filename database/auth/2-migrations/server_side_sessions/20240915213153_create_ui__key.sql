-- up
if dingo.exists_table('ServerSideSessions', 'dbo') = 1 and
   dingo.exists_index('ServerSideSessions', 'IX_ServerSideSessions_Key', 'dbo') = 0
begin
    create unique index IX_ServerSideSessions_Key on dbo.ServerSideSessions ([Key])
end

-- down
if dingo.exists_index('ServerSideSessions', 'IX_ServerSideSessions_Key', 'dbo') = 1
begin
    drop index IX_ServerSideSessions_Key on dbo.ServerSideSessions
end
-- up
if dingo.exists_table('PushedAuthorizationRequests', 'dbo') = 1 and
   dingo.exists_index('PushedAuthorizationRequests', 'IX_PushedAuthorizationRequests_ExpiresAtUtc', 'dbo') = 0
begin
    create index IX_PushedAuthorizationRequests_ExpiresAtUtc on dbo.PushedAuthorizationRequests (ExpiresAtUtc)
end

-- down
if dingo.exists_index('PushedAuthorizationRequests', 'IX_PushedAuthorizationRequests_ExpiresAtUtc', 'dbo') = 1
begin
    drop index IX_PushedAuthorizationRequests_ExpiresAtUtc on dbo.PushedAuthorizationRequests
end
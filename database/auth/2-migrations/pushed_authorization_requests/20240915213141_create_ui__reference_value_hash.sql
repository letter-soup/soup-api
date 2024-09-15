-- up
if dingo.exists_table('PushedAuthorizationRequests', 'dbo') = 1 and
   dingo.exists_index('PushedAuthorizationRequests', 'IX_PushedAuthorizationRequests_ReferenceValueHash', 'dbo') = 0
begin
    create unique index IX_PushedAuthorizationRequests_ReferenceValueHash on dbo.PushedAuthorizationRequests (ReferenceValueHash)
end

-- down
if dingo.exists_index('PushedAuthorizationRequests', 'IX_PushedAuthorizationRequests_ReferenceValueHash', 'dbo') = 1
begin
    drop index IX_PushedAuthorizationRequests_ReferenceValueHash on dbo.PushedAuthorizationRequests
end
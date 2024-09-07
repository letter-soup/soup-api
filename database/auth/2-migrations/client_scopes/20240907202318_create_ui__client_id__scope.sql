-- up
if dingo.exists_table('ClientScopes', 'dbo') = 1 and
   dingo.exists_index('ClientScopes', 'IX_ClientScopes_ClientId_Scope', 'dbo') = 0
begin
    create unique index IX_ClientScopes_ClientId_Scope on dbo.ClientScopes (ClientId, Scope)
end

-- down
if dingo.exists_index('ClientScopes', 'IX_ClientScopes_ClientId_Scope', 'dbo') = 1
begin
    drop index IX_ClientScopes_ClientId_Scope on dbo.ClientScopes
end

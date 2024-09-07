-- up
if dingo.exists_table('ApiResourceScopes', 'dbo') = 1 and
   dingo.exists_index('ApiResourceScopes', 'IX_ApiResourceScopes_ApiResourceId_Scope', 'dbo') = 0
begin
    create unique index IX_ApiResourceScopes_ApiResourceId_Scope on dbo.ApiResourceScopes (ApiResourceId, Scope)
end

-- down
if dingo.exists_index('ApiResourceScopes', 'IX_ApiResourceScopes_ApiResourceId_Scope', 'dbo') = 1
begin
    drop index IX_ApiResourceScopes_ApiResourceId_Scope on dbo.ApiResourceScopes
end

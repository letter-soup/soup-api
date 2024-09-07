-- up
if dingo.exists_table('ApiScopeClaims', 'dbo') = 1 and
   dingo.exists_index('ApiScopeClaims', 'IX_ApiScopeClaims_ScopeId_Type', 'dbo') = 0
begin
    create unique index IX_ApiScopeClaims_ScopeId_Type on dbo.ApiScopeClaims (ScopeId, Type)
end

-- down
if dingo.exists_index('ApiScopeClaims', 'IX_ApiScopeClaims_ScopeId_Type', 'dbo') = 1
begin
    drop index IX_ApiScopeClaims_ScopeId_Type on dbo.ApiScopeClaims
end

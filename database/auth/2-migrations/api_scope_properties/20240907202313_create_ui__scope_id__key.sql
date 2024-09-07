-- up
if dingo.exists_table('ApiScopeProperties', 'dbo') = 1 and
   dingo.exists_index('ApiScopeProperties', 'IX_ApiScopeProperties_ScopeId_Key', 'dbo') = 0
begin
    create unique index IX_ApiScopeProperties_ScopeId_Key on dbo.ApiScopeProperties (ScopeId, [Key])
end

-- down
if dingo.exists_index('ApiScopeProperties', 'IX_ApiScopeProperties_ScopeId_Key', 'dbo') = 1
begin
    drop index IX_ApiScopeProperties_ScopeId_Key on dbo.ApiScopeProperties
end

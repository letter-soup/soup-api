-- up
if dingo.exists_table('ApiResourceClaims', 'dbo') = 1 and
   dingo.exists_index('ApiResourceClaims', 'IX_ApiResourceClaims_ApiResourceId_Type', 'dbo') = 0
begin
    create unique index IX_ApiResourceClaims_ApiResourceId_Type on dbo.ApiResourceClaims (ApiResourceId, Type)
end

-- down
if dingo.exists_index('ApiResourceClaims', 'IX_ApiResourceClaims_ApiResourceId_Type', 'dbo') = 1
begin
    drop index IX_ApiResourceClaims_ApiResourceId_Type on dbo.ApiResourceClaims
end

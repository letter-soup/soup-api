-- up
if dingo.exists_table('ApiResourceSecrets', 'dbo') = 1 and
   dingo.exists_index('ApiResourceSecrets', 'IX_ApiResourceSecrets_ApiResourceId', 'dbo') = 0
begin
    create index IX_ApiResourceSecrets_ApiResourceId on dbo.ApiResourceSecrets (ApiResourceId)
end

-- down
if dingo.exists_index('ApiResourceSecrets', 'IX_ApiResourceSecrets_ApiResourceId', 'dbo') = 1
begin
    drop index IX_ApiResourceSecrets_ApiResourceId on dbo.ApiResourceSecrets
end

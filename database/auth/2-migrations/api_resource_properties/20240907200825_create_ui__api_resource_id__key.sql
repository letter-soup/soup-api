-- up
if dingo.exists_table('ApiResourceProperties', 'dbo') = 1 and
   dingo.exists_index('ApiResourceProperties', 'IX_ApiResourceProperties_ApiResourceId_Key', 'dbo') = 0
begin
    create unique index IX_ApiResourceProperties_ApiResourceId_Key on dbo.ApiResourceProperties (ApiResourceId, [Key])
end

-- down
if dingo.exists_index('ApiResourceProperties', 'IX_ApiResourceProperties_ApiResourceId_Key', 'dbo') = 1
begin
    drop index IX_ApiResourceProperties_ApiResourceId_Key on dbo.ApiResourceProperties
end

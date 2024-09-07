-- up
if dingo.exists_table('ApiResources', 'dbo') = 1 and
   dingo.exists_index('ApiResources', 'IX_ApiResources_Name', 'dbo') = 0
begin
    create unique index IX_ApiResources_Name on dbo.ApiResources (Name)
end

-- down
if dingo.exists_index('ApiResources', 'IX_ApiResources_Name', 'dbo') = 1
begin
    drop index IX_ApiResources_Name on dbo.ApiResources
end

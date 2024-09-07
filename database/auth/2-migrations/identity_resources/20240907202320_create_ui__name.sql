-- up
if dingo.exists_table('IdentityResources', 'dbo') = 1 and
   dingo.exists_index('IdentityResources', 'IX_IdentityResources_Name', 'dbo') = 0
begin
    create unique index IX_IdentityResources_Name on dbo.IdentityResources (Name)
end

-- down
if dingo.exists_index('IdentityResources', 'IX_IdentityResources_Name', 'dbo') = 1
begin
    drop index IX_IdentityResources_Name on dbo.IdentityResources
end

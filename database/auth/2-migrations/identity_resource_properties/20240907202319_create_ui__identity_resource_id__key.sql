-- up
if dingo.exists_table('IdentityResourceProperties', 'dbo') = 1 and
   dingo.exists_index('IdentityResourceProperties', 'IX_IdentityResourceProperties_IdentityResourceId_Key', 'dbo') = 0
begin
    create unique index IX_IdentityResourceProperties_IdentityResourceId_Key on dbo.IdentityResourceProperties (IdentityResourceId, [Key])
end

-- down
if dingo.exists_index('IdentityResourceProperties', 'IX_IdentityResourceProperties_IdentityResourceId_Key', 'dbo') = 1
begin
    drop index IX_IdentityResourceProperties_IdentityResourceId_Key on dbo.IdentityResourceProperties
end

-- up
if dingo.exists_table('IdentityResourceClaims', 'dbo') = 1 and
   dingo.exists_index('IdentityResourceClaims', 'IX_IdentityResourceClaims_IdentityResourceId_Type', 'dbo') = 0
begin
    create unique index IX_IdentityResourceClaims_IdentityResourceId_Type on dbo.IdentityResourceClaims (IdentityResourceId, Type)
end

-- down
if dingo.exists_index('IdentityResourceClaims', 'IX_IdentityResourceClaims_IdentityResourceId_Type', 'dbo') = 1
begin
    drop index IX_IdentityResourceClaims_IdentityResourceId_Type on dbo.IdentityResourceClaims
end

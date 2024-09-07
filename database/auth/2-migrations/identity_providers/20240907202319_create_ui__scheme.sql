-- up
if dingo.exists_table('IdentityProviders', 'dbo') = 1 and
   dingo.exists_index('IdentityProviders', 'IX_IdentityProviders_Scheme', 'dbo') = 0
begin
    create unique index IX_IdentityProviders_Scheme on dbo.IdentityProviders (Scheme)
end

-- down
if dingo.exists_index('IdentityProviders', 'IX_IdentityProviders_Scheme', 'dbo') = 1
begin
    drop index IX_IdentityProviders_Scheme on dbo.IdentityProviders
end

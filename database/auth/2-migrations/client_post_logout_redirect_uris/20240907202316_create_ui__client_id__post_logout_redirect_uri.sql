-- up
if dingo.exists_table('ClientPostLogoutRedirectUris', 'dbo') = 1 and
   dingo.exists_index('ClientPostLogoutRedirectUris', 'IX_ClientPostLogoutRedirectUris_ClientId_PostLogoutRedirectUri', 'dbo') = 0
begin
    create unique index IX_ClientPostLogoutRedirectUris_ClientId_PostLogoutRedirectUri on dbo.ClientPostLogoutRedirectUris (ClientId, PostLogoutRedirectUri)
end

-- down
if dingo.exists_index('ClientPostLogoutRedirectUris', 'IX_ClientPostLogoutRedirectUris_ClientId_PostLogoutRedirectUri', 'dbo') = 1
begin
    drop index IX_ClientPostLogoutRedirectUris_ClientId_PostLogoutRedirectUri on dbo.ClientPostLogoutRedirectUris
end

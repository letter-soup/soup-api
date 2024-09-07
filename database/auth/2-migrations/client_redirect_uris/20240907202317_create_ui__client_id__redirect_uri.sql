-- up
if dingo.exists_table('ClientRedirectUris', 'dbo') = 1 and
   dingo.exists_index('ClientRedirectUris', 'IX_ClientRedirectUris_ClientId_RedirectUri', 'dbo') = 0
begin
    create unique index IX_ClientRedirectUris_ClientId_RedirectUri on dbo.ClientRedirectUris (ClientId, RedirectUri)
end

-- down
if dingo.exists_index('ClientRedirectUris', 'IX_ClientRedirectUris_ClientId_RedirectUri', 'dbo') = 1
begin
    drop index IX_ClientRedirectUris_ClientId_RedirectUri on dbo.ClientRedirectUris
end

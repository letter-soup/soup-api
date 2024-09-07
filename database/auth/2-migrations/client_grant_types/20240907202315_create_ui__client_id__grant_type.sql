-- up
if dingo.exists_table('ClientGrantTypes', 'dbo') = 1 and
   dingo.exists_index('ClientGrantTypes', 'IX_ClientGrantTypes_ClientId_GrantType', 'dbo') = 0
begin
    create unique index IX_ClientGrantTypes_ClientId_GrantType on dbo.ClientGrantTypes (ClientId, GrantType)
end

-- down
if dingo.exists_index('ClientGrantTypes', 'IX_ClientGrantTypes_ClientId_GrantType', 'dbo') = 1
begin
    drop index IX_ClientGrantTypes_ClientId_GrantType on dbo.ClientGrantTypes
end

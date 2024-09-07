-- up
if dingo.exists_table('ClientSecrets', 'dbo') = 1 and
   dingo.exists_index('ClientSecrets', 'IX_ClientSecrets_ClientId', 'dbo') = 0
begin
    create index IX_ClientSecrets_ClientId on dbo.ClientSecrets (ClientId)
end

-- down
if dingo.exists_index('ClientSecrets', 'IX_ClientSecrets_ClientId', 'dbo') = 1
begin
    drop index IX_ClientSecrets_ClientId on dbo.ClientSecrets
end

-- up
if dingo.exists_table('Clients', 'dbo') = 1 and
   dingo.exists_index('Clients', 'IX_Clients_ClientId', 'dbo') = 0
begin
    create unique index IX_Clients_ClientId on dbo.Clients (ClientId)
end

-- down
if dingo.exists_index('Clients', 'IX_Clients_ClientId', 'dbo') = 1
begin
    drop index IX_Clients_ClientId on dbo.Clients
end

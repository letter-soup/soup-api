-- up
if dingo.exists_table('ClientCorsOrigins', 'dbo') = 1 and
   dingo.exists_index('ClientCorsOrigins', 'IX_ClientCorsOrigins_ClientId_Origin', 'dbo') = 0
begin
    create unique index IX_ClientCorsOrigins_ClientId_Origin on dbo.ClientCorsOrigins (ClientId, Origin)
end

-- down
if dingo.exists_index('ClientCorsOrigins', 'IX_ClientCorsOrigins_ClientId_Origin', 'dbo') = 1
begin
    drop index IX_ClientCorsOrigins_ClientId_Origin on dbo.ClientCorsOrigins
end

-- up
if dingo.exists_table('ClientClaims', 'dbo') = 1 and
   dingo.exists_index('ClientClaims', 'IX_ClientClaims_ClientId_Type_Value', 'dbo') = 0
begin
    create unique index IX_ClientClaims_ClientId_Type_Value on dbo.ClientClaims (ClientId, Type, Value)
end

-- down
if dingo.exists_index('ClientClaims', 'IX_ClientClaims_ClientId_Type_Value', 'dbo') = 1
begin
    drop index IX_ClientClaims_ClientId_Type_Value on dbo.ClientClaims
end

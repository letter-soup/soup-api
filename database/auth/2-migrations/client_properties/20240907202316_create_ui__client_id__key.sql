-- up
if dingo.exists_table('ClientProperties', 'dbo') = 1 and
   dingo.exists_index('ClientProperties', 'IX_ClientProperties_ClientId_Key', 'dbo') = 0
begin
    create unique index IX_ClientProperties_ClientId_Key on dbo.ClientProperties (ClientId, [Key])
end

-- down
if dingo.exists_index('ClientProperties', 'IX_ClientProperties_ClientId_Key', 'dbo') = 1
begin
    drop index IX_ClientProperties_ClientId_Key on dbo.ClientProperties
end

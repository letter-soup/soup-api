-- up
if dingo.exists_table('ClientIdPRestrictions', 'dbo') = 1 and
   dingo.exists_index('ClientIdPRestrictions', 'IX_ClientIdPRestrictions_ClientId_Provider', 'dbo') = 0
begin
    create unique index IX_ClientIdPRestrictions_ClientId_Provider on dbo.ClientIdPRestrictions (ClientId, Provider)
end

-- down
if dingo.exists_index('ClientIdPRestrictions', 'IX_ClientIdPRestrictions_ClientId_Provider', 'dbo') = 1
begin
    drop index IX_ClientIdPRestrictions_ClientId_Provider on dbo.ClientIdPRestrictions
end

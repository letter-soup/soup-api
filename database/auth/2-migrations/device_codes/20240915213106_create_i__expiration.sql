-- up
if dingo.exists_table('DeviceCodes', 'dbo') = 1 and
   dingo.exists_index('DeviceCodes', 'IX_DeviceCodes_Expiration', 'dbo') = 0
begin
    create index IX_DeviceCodes_Expiration on dbo.DeviceCodes (Expiration)
end

-- down
if dingo.exists_index('DeviceCodes', 'IX_DeviceCodes_Expiration', 'dbo') = 1
begin
    drop index IX_DeviceCodes_Expiration on dbo.DeviceCodes
end
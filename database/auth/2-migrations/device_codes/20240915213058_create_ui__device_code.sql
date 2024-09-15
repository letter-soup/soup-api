-- up
if dingo.exists_table('DeviceCodes', 'dbo') = 1 and
   dingo.exists_index('DeviceCodes', 'IX_DeviceCodes_DeviceCode', 'dbo') = 0
begin
    create unique index IX_DeviceCodes_DeviceCode on dbo.DeviceCodes (DeviceCode)
end

-- down
if dingo.exists_index('DeviceCodes', 'IX_DeviceCodes_DeviceCode', 'dbo') = 1
begin
    drop index IX_DeviceCodes_DeviceCode on dbo.DeviceCodes
end
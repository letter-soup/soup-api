-- up
if dingo.exists_table('ApiScopes', 'dbo') = 1 and
   dingo.exists_index('ApiScopes', 'IX_ApiScopes_Name', 'dbo') = 0
begin
    create unique index IX_ApiScopes_Name on dbo.ApiScopes (Name)
end

-- down
if dingo.exists_index('ApiScopes', 'IX_ApiScopes_Name', 'dbo') = 1
begin
    drop index IX_ApiScopes_Name on dbo.ApiScopes
end

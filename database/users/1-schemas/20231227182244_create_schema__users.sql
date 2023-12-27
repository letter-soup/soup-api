-- up
do $$begin
    if (select exists(select schema_name from information_schema.schemata where schema_name = 'users') is false) then
        create schema "users";
    end if;
end$$;

-- down
do $$begin
    if (select exists(select schema_name from information_schema.schemata where schema_name = 'users') is true) then
        drop schema "users";
    end if;
end$$;
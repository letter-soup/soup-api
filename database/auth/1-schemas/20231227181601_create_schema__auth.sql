-- up
do $$begin
    if (select exists(select schema_name from information_schema.schemata where schema_name = 'auth') is false) then
        create schema "auth";
    end if;
end$$;

-- down
do $$begin
    if (select exists(select schema_name from information_schema.schemata where schema_name = 'auth') is true) then
        drop schema "auth";
    end if;
end$$;
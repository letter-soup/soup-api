# Soup

## Tooling

First, install tools required for the development process:

- [.NET SDK (v8)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [docker](https://docs.docker.com/engine/install/)
- [PostgreSQL (using docker)](https://www.docker.com/blog/how-to-use-the-postgres-docker-official-image/)
- [dingo](https://ujinjinjin.github.io/dingo/dingo.html#installation)

## Configure local environment

### Configure local database

Ensure that `PostgreSQL` container is running and you are able to connect to database.
Then, at the repository root execute the following command to initialize `dingo` profile:

```shell
dingo init -c local
```

Open `.dingo/config.local.yml` and paste configuration template replacing `$CONNECTION_STRING$` with an actual connection string:

```yaml
db:
  connection-string: $CONNECTION_STRING$
  provider: PostgreSQL
migration:
  down-required: true
log:
  level: Information
```

Check that `dingo` is able to connect to the database:

```shell
dingo db ping -c local
```

Apply migrations:

```shell
dingo up -c local -p database/
```

## Run application

### Self hosted

### Using docker

## Branching model

## Test coverage

## Develop new feature
using Auth.Wiedersehen.Database.Migrations;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace Auth.Wiedersehen.IntegrationTests;

public abstract class IntegrationTestBase : IAsyncLifetime
{
    private WebApplicationFactory<Program> _factory = null!;
    private string _connectionString = null!;
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:17")
        .Build();

    protected HttpClient Client { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        _connectionString = _dbContainer.GetConnectionString();

        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Tests");
                builder.ConfigureServices(services =>
                {
                    ReplaceDbContext<ApplicationDbContext>(services);
                    ReplaceDbContext<ConfigurationDbContext>(services);
                    ReplaceDbContext<PersistedGrantDbContext>(services);
                });
            });

        Client = _factory.CreateClient();

        using var scope = _factory.Services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
        await scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.MigrateAsync();
        await scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();
    }

    private void ReplaceDbContext<TContext>(IServiceCollection services) where TContext : DbContext
    {
        services.RemoveDbContext<TContext>();
        services.AddDbContext<TContext>(options =>
        {
            options.UseNpgsql(_connectionString);
        });
        // services.EnsureDbCreated<TContext>();
    }

    public async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
        await _factory.DisposeAsync();
    }
}

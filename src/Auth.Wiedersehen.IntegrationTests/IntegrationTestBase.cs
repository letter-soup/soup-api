using Auth.Wiedersehen.Configuration;
using Auth.Wiedersehen.Database.Migrations;
using Auth.Wiedersehen.IntegrationTests.Extensions;
using Auth.Wiedersehen.Seeder.Dataset;
using Auth.Wiedersehen.Users;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
	protected readonly IFixture Fixture = new Fixture();

	protected const string TestClientId = "test-client";
	protected const string TestClientSecret = "test-secret";

	public async Task InitializeAsync()
	{
		await _dbContainer.StartAsync();
		_connectionString = _dbContainer.GetConnectionString();

		_factory = new WebApplicationFactory<Program>()
			.WithWebHostBuilder(builder =>
				{
					builder.UseEnvironment("Tests");
					builder.ConfigureAppConfiguration((_, config) =>
						{
							config.AddInMemoryCollection(
								new Dictionary<string, string?>
								{
									{
										$"ConnectionStrings:{ConfigurationKey.ConnectionString.ApplicationDb}",
										_connectionString
									},
									{
										$"ConnectionStrings:{ConfigurationKey.ConnectionString.ConfigurationDb}",
										_connectionString
									},
									{
										$"ConnectionStrings:{ConfigurationKey.ConnectionString.PersistentGrandDb}",
										_connectionString
									}
								}
							);
						}
					);
					builder.ConfigureServices(services =>
						{
							ReplaceDbContext<ApplicationDbContext>(services);
							ReplaceDbContext<ConfigurationDbContext>(services);
							ReplaceDbContext<PersistedGrantDbContext>(services);
						}
					);
				}
			);

		Client = _factory.CreateClient();

		using var scope = _factory.Services.CreateScope();
		await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
		await scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.MigrateAsync();
		await scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();

		SeedIdentityServer(scope.ServiceProvider);
	}

	private void SeedIdentityServer(IServiceProvider serviceProvider)
	{
		var context = serviceProvider.GetRequiredService<ConfigurationDbContext>();
		var dataset = new DevDataset();

		if (!context.Clients.Any())
		{
			foreach (var client in dataset.Clients)
			{
				context.Clients.Add(client.ToEntity());
			}

			// Add a test client for integration tests
			context.Clients.Add(
				new Client
				{
					ClientId = TestClientId,
					ClientSecrets = { new Secret(TestClientSecret.Sha256()) },
					AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
					AllowedScopes = { "openid", "profile", "soup" },
					AllowOfflineAccess = true
				}.ToEntity()
			);

			context.SaveChanges();
		}

		if (!context.IdentityResources.Any())
		{
			foreach (var resource in dataset.IdentityResources)
			{
				context.IdentityResources.Add(resource.ToEntity());
			}

			context.SaveChanges();
		}

		if (!context.ApiScopes.Any())
		{
			foreach (var scope in dataset.ApiScopes)
			{
				context.ApiScopes.Add(scope.ToEntity());
			}

			context.SaveChanges();
		}
	}

	private void ReplaceDbContext<TContext>(IServiceCollection services) where TContext : DbContext
	{
		services.RemoveDbContext<TContext>();
		services.AddDbContext<TContext>(options => { options.UseNpgsql(_connectionString); });
		// services.EnsureDbCreated<TContext>();
	}

	public async Task DisposeAsync()
	{
		await _dbContainer.StopAsync();
		await _factory.DisposeAsync();
	}

	protected async Task<CreateUserRequest> RegisterUserAsync()
	{
		var request = new CreateUserRequest(Fixture.CreateEmail(), Fixture.CreatePassword(), true);
		await Client.CreateUserAsync(request, HttpClientMode.VerifySuccess);
		return request;
	}
}

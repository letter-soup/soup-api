using Auth.Wiedersehen.Database.Migrations;
using Auth.Wiedersehen.IntegrationTests.Extensions;
using Auth.Wiedersehen.IntegrationTests.Fixtures;
using Auth.Wiedersehen.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Wiedersehen.IntegrationTests;

[Collection(nameof(IntegrationTestsCollection))]
public abstract class IntegrationTestBase(IntegrationTestFixture fixture) : IAsyncLifetime
{
	private IServiceScope _transactionScope = null!;

	protected HttpClient Client { get; private set; } = null!;
	protected readonly IFixture Fixture = new Fixture();

	protected const string TestClientId = "test-client";
	protected const string TestClientSecret = "test-secret";

	public async Task InitializeAsync()
	{
		Client = fixture.Factory.CreateClient();

		// Start a per-test transaction for isolation
		_transactionScope = fixture.Factory.Services.CreateScope();
		ApplicationDbContext dbContext = _transactionScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
		await dbContext.Database.BeginTransactionAsync();
	}

	public async Task DisposeAsync()
	{
		// Roll back the transaction to restore DB state
		ApplicationDbContext dbContext = _transactionScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
		await dbContext.Database.CurrentTransaction!.RollbackAsync();
		_transactionScope.Dispose();
	}

	protected async Task<CreateUserRequest> RegisterUserAsync()
	{
		var request = new CreateUserRequest(Fixture.CreateEmail(), Fixture.CreatePassword(), true);
		await Client.CreateUserAsync(request, HttpClientMode.VerifySuccess);
		return request;
	}
}

using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;

namespace Auth.Wiedersehen.Seeder.Dataset;

public static class Seeder
{
	public static void SeedDatabase(this IApplicationBuilder app, IEnvDataset dataset)
	{
		using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();

		var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
		if (!context.Clients.Any())
		{
			foreach (var client in dataset.Clients)
			{
				context.Clients.Add(client.ToEntity());
			}

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
}

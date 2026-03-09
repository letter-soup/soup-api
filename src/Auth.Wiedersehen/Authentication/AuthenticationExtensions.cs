using Auth.Wiedersehen.Configuration;
using Auth.Wiedersehen.Database.Migrations;
using Auth.Wiedersehen.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth.Wiedersehen.Authentication;

internal static class AuthenticationExtensions
{
	public static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
	{
		builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();

		builder.Services
			.AddIdentityServer()
			.AddServerSideSessions()
			.AddConfigurationStore(options =>
				{
					options.ConfigureDbContext = b =>
						b.UseNpgsql(
							builder.Configuration.GetConnectionString(
								ConfigurationKey.ConnectionString.ConfigurationDb
							),
							sql => sql.MigrationsAssembly(GetMigrationAssembly())
						);
				}
			)
			.AddOperationalStore(options =>
				{
					options.ConfigureDbContext = b =>
						b.UseNpgsql(
							builder.Configuration.GetConnectionString(
								ConfigurationKey.ConnectionString.PersistentGrandDb
							),
							sql => sql.MigrationsAssembly(GetMigrationAssembly())
						);
				}
			)
			.AddAspNetIdentity<ApplicationUser>();

		builder.Services.AddAuthentication();

		return builder;
	}

	public static WebApplication UseAuthentication(this WebApplication app)
	{
		app.UseIdentityServer();
		app.UseAuthorization();

		return app;
	}

	private static string? GetMigrationAssembly()
	{
		return typeof(Program).Assembly.GetName().Name;
	}
}

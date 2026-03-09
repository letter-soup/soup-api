using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Auth.Wiedersehen.Seeder;

internal static class WebAppExtensions
{
	private const string EnvVarPrefix = "AWSEED_";

	public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Configuration
			.AddJsonFile(builder.GetAppSettingPath())
			.AddEnvironmentVariables(EnvVarPrefix);

		builder.Services
			.AddAuthorization()
			.AddIdentityServer()
			.AddConfigurationStore(options =>
				{
					options.ConfigureDbContext = b =>
						b.UseNpgsql(
							builder.Configuration.GetConnectionString("ConfigurationDB"),
							sql => sql.MigrationsAssembly(GetMigrationAssembly())
						);
				}
			)
			.AddOperationalStore(options =>
				{
					options.ConfigureDbContext = b =>
						b.UseNpgsql(
							builder.Configuration.GetConnectionString("PersistentGrandDB"),
							sql => sql.MigrationsAssembly(GetMigrationAssembly())
						);
				}
			);

		return builder.Build();
	}

	public static WebApplication ConfigurePipeline(this WebApplication app)
	{
		app.UseSerilogRequestLogging();

		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseIdentityServer();
		app.UseAuthorization();

		return app;
	}

	private static string? GetMigrationAssembly()
	{
		return typeof(Program).Assembly.GetName().Name;
	}

	private static string GetAppSettingPath(this WebApplicationBuilder builder)
	{
		return $"AppSettings/appsettings.{builder.GetEnvironmentName()}.json";
	}

	private static string GetEnvironmentName(this WebApplicationBuilder builder)
	{
		return string.IsNullOrWhiteSpace(builder.Environment.EnvironmentName)
			? "Production"
			: builder.Environment.EnvironmentName;
	}
}

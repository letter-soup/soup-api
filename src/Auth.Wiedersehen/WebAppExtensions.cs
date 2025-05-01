using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Auth.Wiedersehen;

internal static class WebAppExtensions
{
    private const string EnvVarPrefix = "AUTHW_";

    public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(ctx.Configuration));

        return builder;
    }

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Configuration
            .AddJsonFile(builder.GetAppSettingPath())
            .AddEnvironmentVariables(EnvVarPrefix);
        builder.Services
            .AddIdentityServer()
            .AddServerSideSessions()
            .AddConfigurationStore(options => {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(builder.Configuration.GetValue<string>("Database:ConnectionString"));
            })
            .AddOperationalStore(options => {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(builder.Configuration.GetValue<string>("Database:ConnectionString"));
            });
        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            // app.InitializeDatabase();
        }
        
        app.UseIdentityServer();

        return app;
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
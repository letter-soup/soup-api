using Soup.Api.AppSettings;

namespace Soup.Api.Extensions;

internal static class WebAppExtensions
{
    private const string EnvVarPrefix = "SOUP_API_";

    public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
    {
        return builder;
    }

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Configuration
            .AddInMemoryCollection(DefaultConfiguration.Get()!)
            .AddJsonFile(builder.GetAppSettingPath())
            .AddEnvironmentVariables(EnvVarPrefix);

        return builder;
    }

    public static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration.GetValue<string>("Auth:Jwt:Authority");
                options.TokenValidationParameters.ValidateAudience =
                    builder.Configuration.GetValue<bool>("Auth:Jwt:ValidateAudience");
                options.TokenValidationParameters.ValidIssuers =
                    builder.Configuration.GetValue<string[]>("Auth:Jwt:ValidIssuers");
                options.RequireHttpsMetadata = builder.Configuration.GetValue<bool>("Auth:Jwt:RequireHttpsMetadata");
            });

        return builder;
    }

    public static WebApplicationBuilder ConfigureAuthorization(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorizationBuilder().AddPolicy("ApiScope", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "soup");
        });

        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();

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
namespace Soup.Api.Extensions;

internal static class WebAppExtensions
{
    public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
    {
        return builder;
    }

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Configuration.AddJsonFile(builder.GetAppSettingPath());

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
using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.Controllers.Services;
using Auth.Wiedersehen.Database.Migrations;
using Auth.Wiedersehen.Database.Models;
using Auth.Wiedersehen.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Auth.Wiedersehen.Extensions;

internal static class WebAppExtensions
{
    private const string EnvVarPrefix = "AUTHW_";

    public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}"
            )
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(ctx.Configuration),
            preserveStaticLogger: true
        );

        return builder;
    }

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
        builder.Services.AddScoped<IValidator<EmailAvailableRequest>, EmailAvailableRequestValidator>();

        builder.Services.AddTransient(typeof(ILocalizer<>), typeof(LocalizerAdapter<>));

        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        builder.Services.AddControllers(options => options.Filters.Add<HttpResponseExceptionFilter>());
        builder.Services.AddOpenApi();

        builder.Configuration
            .AddJsonFile(builder.GetAppSettingPath())
            .AddEnvironmentVariables(EnvVarPrefix);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDB"))
        );

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
            )
            .AddAspNetIdentity<ApplicationUser>();

        builder.Services.AddAuthentication();

        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        var supportedCultures = new[] { "en-US", "en" };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);

        app.UseSerilogRequestLogging();
        app.MapControllers();
        app.MapOpenApi();

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
using Soup.Api.Extensions;

namespace Soup.Api;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder
            .ConfigureLogging()
            .ConfigureServices()
            .ConfigureAuthentication()
            .ConfigureAuthorization()
            .Build();

        await app.ConfigurePipeline().RunAsync();
    }
}
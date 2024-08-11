using Serilog;

namespace Auth.Wiedersehen;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateBootstrapLogger();
        Log.Information("Starting up");

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder
                .ConfigureLogging()
                .ConfigureServices()
                .Build();

            await app.ConfigurePipeline().RunAsync();
        }
        catch (Exception e)
        {
            Log.Fatal(e, "Unhandled exception");
            throw;
        }
        finally
        {
            Log.Information("Shut down complete");
            await Log.CloseAndFlushAsync();
        }
    }
}

using Duende.IdentityServer.Models;

namespace Auth.Wiedersehen.Seeder.Dataset;

public interface IEnvDataset
{
    IEnumerable<IdentityResource> IdentityResources { get; }
    IEnumerable<ApiScope> ApiScopes { get; }
    IEnumerable<Client> Clients { get; }
}
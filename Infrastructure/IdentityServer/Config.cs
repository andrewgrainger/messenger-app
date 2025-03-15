using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        ];

    public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope("messenger.read"),
            new ApiScope("messenger.write")
        ];

    public static IEnumerable<ApiResource> ApiResources =>
        [
            new ApiResource("Messenger", "Messenger.API")
            {
                Scopes = { "messenger.read", "messenger.write" }
            }
        ];

    public static IEnumerable<Client> Clients =>
        [
             // m2m flow
            new Client
            {
                ClientName = "Messenger API Client",
                ClientId = "MessengerAPIClient",
                ClientSecrets = { new Secret("252acb8d-dd21-40bb-941e-413a768083d5".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "messenger.read", "messenger.write" }
            }
        ];
}

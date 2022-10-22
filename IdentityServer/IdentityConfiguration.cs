using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class IdentityConfiguration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("MeetupAPI", "Web API"),
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("MeetupAPI", "Web API")
                {
                    Scopes = new List<string> { "MeetupAPI" },
                    ApiSecrets = new List<Secret>{ new Secret("my-api-secret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "meetup-web-api",
                    ClientName = "Meetup API",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("meetup-api-secret".Sha256()) },
                    AllowedScopes = { "MeetupAPI" }
                },
            };
    }
}

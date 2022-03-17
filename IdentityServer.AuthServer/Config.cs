using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("resource_api1") { Scopes = { "api1.read", "api1.write", "api1.update" } },
                new ApiResource("resource_api2") { Scopes = { "api2.read", "api2.write", "api2.update" } }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("api1.read", "Read for API 1"),
                new ApiScope("api1.write", "Read for API 1"),
                new ApiScope("api1.update", "Read for API 1"),
                new ApiScope("api2.read", "Read for API 2"),
                new ApiScope("api2.write", "Read for API 2"),
                new ApiScope("api2.update", "Read for API 2")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "Client1",
                    ClientName = "Client 1 api",
                    ClientSecrets = new[] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new[] { "api1.read" }
                },
                new Client()
                {
                    ClientId = "Client2",
                    ClientName = "Client 2 api",
                    ClientSecrets = new[] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new[] { "api1.read", "api2.write", "api2.update" }
                }
            };
        }
    }
}

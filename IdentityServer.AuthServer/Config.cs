using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer.AuthServer
{
  public static class Config
  {
    public static IEnumerable<ApiResource> GetApiResources()
    {
      return new[]
      {
                new ApiResource("resource_api1") { Scopes = { "api1.read", "api1.write", "api1.update" }, ApiSecrets = {new Secret("secretapi".Sha256())} },
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
                    AllowedScopes = new[] { "api1.read", "api1.update", "api2.write", "api2.update" }
                },
                new Client()
                {
                    ClientId = "Client1-Mvc",
                    ClientName = "Client1 mvc api",
                    RequirePkce=false,
                    ClientSecrets = new[] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new[] { "https://localhost:5002/signin-oidc" },
                    AllowedScopes = new[] {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
    }

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
      return new IdentityResource[]
      {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
      };
    }
    public static IEnumerable<TestUser> GetTestUsers()
    {
      return new[]
      {
                new TestUser {
                    SubjectId = "1",
                    Username = "ozan",
                    Password = "password",
                    Claims = new[]
                    {
                        new Claim("given_name", "Ozan"),
                        new Claim("family_name", "Honamlıoğlu")
                    }
                },
                new TestUser {
                    SubjectId = "2",
                    Username = "aysegul",
                    Password = "password",
                    Claims = new[]
                    {
                        new Claim("given_name", "Ayşegül"),
                        new Claim("family_name", "Honamlıoğlu")
                    }
                }
            };
    }
  }
}

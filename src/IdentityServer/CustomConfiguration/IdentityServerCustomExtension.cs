using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using IdentityServer4.Models;
using IdentityServer4;

namespace IdentityServer.CustomConfiguration
{
    public static class IdentityServerCustomExtension
    {

        #region private

        private static IEnumerable<IdentityResource> GetIdentityResources(IdentityServerConfiguration configuration)
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis(IdentityServerConfiguration configuration)
        {
            return new List<ApiResource>
                {
                    new ApiResource(configuration.Api, configuration.ApiName)
                };
        }

        public static IEnumerable<Client> GetClients(IdentityServerConfiguration configuration)
        {

            var clients = new List<Client>();

            foreach (var clientCfg in configuration.Clients)
            {
                clients.Add(new Client()
                {
                    ClientId = clientCfg.ClientId,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = clientCfg.AccessTokenLifetime ?? 3600, 
                    IdentityTokenLifetime = clientCfg.IdentityTokenLifetime ?? 3600, 
                    UpdateAccessTokenClaimsOnRefresh = true,
                    SlidingRefreshTokenLifetime = 30,
                    AllowOfflineAccess = true,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AlwaysSendClientClaims = true,
                    Enabled = true,
                    ClientSecrets = new List<Secret> { new Secret(clientCfg.Secret.Sha256()) },
                    AllowedScopes = {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                            IdentityServerConstants.StandardScopes.OfflineAccess,
                            configuration.Api
                        }
                });
            }
;            return clients;

        }

        #endregion

        public static void AddIdentityServerCustomConfiguration(this IServiceCollection services, 
                                                                IConfiguration configuration,
                                                                IHostingEnvironment Environment)
        {
            var identitityServerCfg = new IdentityServerConfiguration();
            configuration.GetSection("IdentityServer").Bind(identitityServerCfg);

            var builder = services.AddIdentityServer()
               .AddInMemoryIdentityResources(GetIdentityResources(identitityServerCfg))
               .AddInMemoryApiResources(GetApis(identitityServerCfg))
               .AddInMemoryClients(GetClients(identitityServerCfg))
               .AddCustomUserStore();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("Certificate isn't configured properly");
            }


        }
    }
}

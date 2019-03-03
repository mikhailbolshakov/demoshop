using DemoShop.Libs.RestClient;
using DemoShop.Libs.RestClient.Contract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.IntegrationTest.TestEnv
{

    public class IdentityServerConfiguration
    {
        public string IdentityServerRootUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
    }

    public class ApiClientFactory
    {

        private Lazy<IDsRestClient> _noAuthApi; 

        private readonly IConfiguration _configuration;

        public ApiClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;

            _noAuthApi = new Lazy<IDsRestClient>(() => 
            {
                var anonymousRestClient = DsRestClientFactory.WithNoAuth(new RestClientParameter()
                {
                    RootUrl = _configuration.GetValue<string>("WebApiUrl")
                });

                return anonymousRestClient;

            }, true);

        }

        public IDsRestClient Api(bool auth = false, string username = null, string pwd = null)
        {
            if (auth)
            {
                var identitityServerCfg = new IdentityServerConfiguration();
                _configuration.GetSection("IdentityServer").Bind(identitityServerCfg);

                var restClient = DsRestClientFactory.WithTokenAuthAsync(new RestClientWithTokenParameter()
                {
                    RootUrl = _configuration.GetValue<string>("WebApiUrl"),
                    IdentityServerRootUrl = identitityServerCfg.IdentityServerRootUrl,
                    ClientId = identitityServerCfg.ClientId,
                    ClientSecret = identitityServerCfg.ClientSecret,
                    Scope = identitityServerCfg.Scope,
                    UserName = username,
                    Password = pwd
                })
                .Result;

                return restClient;
            }
            else
            {
                return _noAuthApi.Value;
            }
        }
    }
}

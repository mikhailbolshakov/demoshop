using DemoShop.Libs.RestClient.Contract;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace DemoShop.Libs.RestClient
{

    public static class DsRestClientFactory
    {
        /// <summary>
        /// creates Rest client without authentication
        /// </summary>
        /// <returns></returns>
        public static IDsRestClient WithNoAuth(RestClientParameter param)
        {
            return new DsRestClient(new HttpClient(), param.RootUrl);
        }

        /// <summary>
        /// creates Rest client with Identity server authentication
        /// </summary>
        /// <returns></returns>
        public async static Task<IDsRestClient> WithTokenAuthAsync(RestClientWithTokenParameter param)
        {
            var client = new HttpClient();

            //  discovery identity server
            var idSrv = await client.GetDiscoveryDocumentAsync(param.IdentityServerRootUrl);
            if (idSrv.IsError)
            {
                throw new Exception($"Error occured while discovering identity server at {param.IdentityServerRootUrl}", idSrv.Exception);
            }

            // request token
            var tkn = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = idSrv.TokenEndpoint,
                ClientId = param.ClientId,
                ClientSecret = param.ClientSecret,
                Scope = param.Scope,
                GrantType = GrantTypes.Password,
                UserName = param.UserName,
                Password = param.Password
            });

            if (tkn.IsError)
            {
                throw new Exception($"Error occured while obtaining a token at {param.IdentityServerRootUrl}", tkn.Exception);
            }
            
            // create a http client and set Bearer Token auth type
            var httpClient = new HttpClient();
            httpClient.SetBearerToken(tkn.AccessToken);

            var restClient = new DsRestClient(httpClient, param.RootUrl);

            return restClient;
        }
    }
}

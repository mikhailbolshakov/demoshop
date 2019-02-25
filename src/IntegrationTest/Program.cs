using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdentityClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // discover endpoints from metadata
            var client = new HttpClient();

            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5000").Result;
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            Console.WriteLine($"disco.TokenEndpoint = {disco.TokenEndpoint}");
        
            // request token
            var tokenResponse = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "demoshop_client",
                ClientSecret = "demoshop_secret",
                Scope = "demoshop_api",
                GrantType = "password",
                UserName = "mike",
                Password = "mike"
                
            }).Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.ErrorDescription);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var userJs = new JObject();
            userJs["UserName"] = "mike";

            var postContent = new StringContent(userJs.ToString(), Encoding.UTF8, "application/json");

            var response = apiClient.PostAsync("http://localhost:5001/api/security/shared/user/create", postContent).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content =  response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(JObject.Parse(content));
            }
        }
    }
}

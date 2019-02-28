using DemoShop.Libs.RestClient;
using DemoShop.Libs.RestClient.Contract;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.IntegrationTest.Security.User
{
    [TestFixture]
    public class UserRegistrationTests
    {

        [Test]
        public async Task FirstTimeRegistrationTest()
        {
            var restClient = await DsRestClientFactory.WithTokenAuthAsync(new RestClientWithTokenParameter()
            {
                RootUrl = "http://localhost:5001",
                IdentityServerRootUrl = "http://localhost:5000",
                ClientId = "demoshop_client",
                ClientSecret = "demoshop_secret",
                Scope = "demoshop_api",
                UserName = "mike",
                Password = "mike",
            });

            var user = new JObject();
            user["UserName"] = "test";
            user["Password"] = "123";
            user["Email"] = "test@gmail.com";

            var rs = await restClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = "api/security/shared/user/create",
                Payload = user.ToString()              
            });

            Assert.AreEqual(HttpStatusCode.OK, rs.StatusCode);

        }
    }
}

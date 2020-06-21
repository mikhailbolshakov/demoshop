using DemoShop.IntegrationTest.TestEnv;
using DemoShop.Libs.RestClient;
using DemoShop.Libs.RestClient.Contract;
using Microsoft.Extensions.DependencyInjection;
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
        private ApiClientFactory _apiClientFactory;

        [SetUp]
        public void Setup()
        {
            _apiClientFactory = new ApiClientFactory(TestConfig.Configuration);
        }

        [Test]
        public async Task FirstTimeRegistrationTest()
        {

            // register a new user
            var anonymousRestClient = _apiClientFactory.Api();

            var userName = $"user_{Guid.NewGuid().ToString().Substring(0, 6)}";

            var user = JObject.FromObject(new
            {
                UserName = userName,
                Password = "123",
                Email = $"{userName}@demoshop.com"
            }
            );

            var rs = await anonymousRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = "api/security/shared/user/register",
                Payload = user.ToString()
            });
            Assert.AreEqual(HttpStatusCode.OK, rs.StatusCode);

            // check if an anonumous method is availabe
            var rsCheckNoAuth = await anonymousRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = "diagnostic/health-check/no-auth",
                Payload = "{}"
            });
            Assert.AreEqual(HttpStatusCode.OK, rsCheckNoAuth.StatusCode);

            // check if authenticated method is availabe
            var authRestClient = _apiClientFactory.Api(true, userName, "123");

            var rsCheckAuth = await authRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = "diagnostic/health-check/auth",
                Payload = "{}"
            });
            Assert.AreEqual(HttpStatusCode.OK, rsCheckAuth.StatusCode);

            // check if current user is correct
            var rsGetUser = await authRestClient.GetAsync(new DsRestRequest()
            {
                ApiUrl = "api/security/shared/user/get-current-user"
            });
            Assert.AreEqual(HttpStatusCode.OK, rsGetUser.StatusCode);

            var userActual = JObject.Parse(rsGetUser.Payload);
            Assert.AreEqual(user["Password"], userActual["Password"]);
            Assert.AreEqual(user["Email"], userActual["Email"]);

        }

        [Test]
        public async Task GrantAndRevokeAdminRoleTest()
        {
            var adminRestClient = _apiClientFactory.Api(true);

            // register a new user
            var userName = $"user_{Guid.NewGuid().ToString().Substring(0, 6)}";

            var user = JObject.FromObject(new
            {
                UserName = userName,
                Password = "123",
                Email = $"{userName}@demoshop.com"
            }
            );

            var rs = await adminRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = "api/security/shared/user/register",
                Payload = user.ToString()
            });
            Assert.AreEqual(HttpStatusCode.OK, rs.StatusCode);

            user = JObject.Parse(rs.Payload);

            var rsGrantUser = await adminRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = "api/security/shared/user/grant",
                Payload = JObject.FromObject(new { UserId = user["UserId"], Roles = new List<string> { "admin" } }).ToString()
            });
            Assert.AreEqual(HttpStatusCode.OK, rsGrantUser.StatusCode);

            var rsRevokeUser = await adminRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = "api/security/shared/user/revoke",
                Payload = JObject.FromObject(new { UserId = user["UserId"], Roles = new List<string> { "admin" } }).ToString()
            });
            Assert.AreEqual(HttpStatusCode.OK, rsRevokeUser.StatusCode);
        }

        [Test]
        public async Task UserNotFoudByIdTest()
        {

            var authRestClient = _apiClientFactory.Api(true);

            // check if current user is correct
            var rsGetUser = await authRestClient.GetAsync(new DsRestRequest()
            {
                ApiUrl = $"api/security/shared/user/get-user/{Guid.NewGuid().ToString()}"
            });
            Assert.AreEqual(HttpStatusCode.NotFound, rsGetUser.StatusCode);
        }

    }
}

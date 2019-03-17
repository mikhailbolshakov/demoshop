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

namespace DemoShop.IntegrationTest.Sale.Product
{
    [TestFixture]
    public class ProductTests
    {
        private ApiClientFactory _apiClientFactory;

        [SetUp]
        public void Setup()
        {
            _apiClientFactory = new ApiClientFactory(TestConfig.Configuration);
        }

        [Test]
        public async Task AddSimpleProductTest()
        {

            var adminRestClient = _apiClientFactory.Api(true);

            var product = JObject.FromObject(
                new
                {
                    ProductCode = "CL_123",
                    Details = new {
                                     Sizes = new int[] { 48, 49, 50},
                                     Type = "T-Shirt"
                                  }
                }
           );

            var rs = await adminRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = "api/sale/shared/product/add-product/clothes",
                Payload = product.ToString()
            });
            Assert.AreEqual(HttpStatusCode.OK, rs.StatusCode);

            dynamic response = JObject.Parse(rs.Payload);

            var price = JObject.FromObject(new
                {   
                    ValidityStartDate = "2019-01-01",
                    ValidityEndDate = "2050-01-01",
                    Amount = 100.0M
                }
            );

            rs = await adminRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = $"api/sale/shared/product/update-price/{response.ProductId}",
                Payload = price.ToString()
            });
            Assert.AreEqual(HttpStatusCode.OK, rs.StatusCode);

        }

        [Test]
        public async Task UpdatePriceWhenProductDoesnExistTest()
        {
            var adminRestClient = _apiClientFactory.Api(true);

            var price = JObject.FromObject(new
            {
                ValidityStartDate = "2019-01-01",
                ValidityEndDate = "2050-01-01",
                Amount = 100.0M
            }
            );

            var rs = await adminRestClient.PostAsync(new DsRestRequest()
            {
                ApiUrl = $"api/sale/shared/product/update-price/{Guid.NewGuid().ToString()}",
                Payload = price.ToString()
            });
            Assert.AreEqual(HttpStatusCode.NotFound, rs.StatusCode);
        }

    }
}

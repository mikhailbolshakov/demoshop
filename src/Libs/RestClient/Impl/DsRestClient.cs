using DemoShop.Libs.RestClient.Contract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Libs.RestClient
{

    public class DsRestClient : IDsRestClient
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiRoot;

        public DsRestClient(HttpClient httpClient, string apiRoot)
        {
            _httpClient = httpClient;
            _apiRoot = apiRoot;
        }

        public async Task<DsRestResponse> PostAsync(DsRestRequest request)
        {
            var postContent = new StringContent(request.Payload, Encoding.UTF8, "application/json");

            var url = $"{_apiRoot}/{request.ApiUrl}";

            var httpRs = await _httpClient.PostAsync(url, postContent);

            if (!httpRs.IsSuccessStatusCode && request.ThrowExceptionOnHttpError)
                throw new Exception($"HTTP request at {url} failed with the status {httpRs.StatusCode}");

            var resp = new DsRestResponse()
            {
                StatusCode = httpRs.StatusCode,
                Payload = httpRs.StatusCode == System.Net.HttpStatusCode.OK
                    ? await httpRs.Content.ReadAsStringAsync()
                    : null
            };

            return resp;
        }
    }
}

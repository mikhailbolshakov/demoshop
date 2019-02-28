using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Libs.RestClient.Contract
{
    public interface IDsRestClient
    {
        /// <summary>
        /// makes POST request with given payload
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DsRestResponse> PostAsync(DsRestRequest request);
    }
}

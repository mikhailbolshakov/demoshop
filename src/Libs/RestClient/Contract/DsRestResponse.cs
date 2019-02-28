using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DemoShop.Libs.RestClient.Contract
{
    public class DsRestResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Payload { get; set; }
    }
}

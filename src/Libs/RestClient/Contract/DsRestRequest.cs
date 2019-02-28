using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.RestClient.Contract
{
    public class DsRestRequest
    {
        public string ApiUrl { get; set; }
        public string Payload { get; set; }
        public bool ThrowExceptionOnHttpError { get; set; }
    }
}

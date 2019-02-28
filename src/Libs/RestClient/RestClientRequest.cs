using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.RestClient
{
    public class RestClientParameter
    {
        public string RootUrl { get; set; }
    }

    public class RestClientWithTokenParameter : RestClientParameter
    {
        public string IdentityServerRootUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

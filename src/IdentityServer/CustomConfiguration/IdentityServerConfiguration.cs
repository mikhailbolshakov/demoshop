using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.CustomConfiguration
{

    public class IdentityServerClient
    {
        public string ClientId { get; set; }
        public int? AccessTokenLifetime { get; set; }
        public int? IdentityTokenLifetime { get; set; }
        public string Secret { get; set; }

    }

    public class IdentityServerConfiguration
    {
        public string Api { get; set; }
        public string ApiName { get; set; }
        public List<IdentityServerClient> Clients { get; set; }
    }
}

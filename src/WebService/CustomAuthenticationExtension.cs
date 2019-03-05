using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace WebService
{

    public class IdentityServerConfiguration
    {
        public string IdentityServerBaseUrl { get; set; }
        public bool RequireHttps { get; set; }
        public string Audience { get; set; }
    }

    public static class CustomAuthenticationExtension
    {
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var identitityServerCfg = new IdentityServerConfiguration();
            configuration.GetSection("IdentityServer").Bind(identitityServerCfg);

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = identitityServerCfg.IdentityServerBaseUrl;
                    options.RequireHttpsMetadata = identitityServerCfg.RequireHttps;
                    options.Audience = identitityServerCfg.Audience;
                });

            services.AddAuthorization(options => options.AddPolicy("Admin", policy => policy.RequireClaim("admin", "1")));
        }
    }
}

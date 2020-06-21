using DemoShop.Libs.DI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoShop.Libs;
using System.Diagnostics;

namespace IdentityServer
{
    public static class DICustomModulesExtention
    {
        private static IEnumerable<IDIModule> Modules()
        {
            return new IDIModule[] 
            {
                new LibModule()
            };
        }

        public static IServiceCollection AddCustomServiceBinding(this IServiceCollection services)
        {
            var modules = Modules().ToList();
            modules.ForEach(m => m.Bind(services));
            var provider = services.BuildServiceProvider();
            modules.ForEach(m => m.Initialize(provider));

            return services;
        }


    }
}

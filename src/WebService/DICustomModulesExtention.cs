using DemoShop.Libs.DI;
using DemoShop.Organization.Bootstrapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoShop.Libs;
using DemoShop.Security.Bootstrapper;
using System.Diagnostics;

namespace WebService
{
    public static class DICustomModulesExtention
    {
        private static IEnumerable<IDIModule> Modules()
        {
            return new IDIModule[] 
            {
                new LibModule(),
                new SecurityModule(),
                new OrganizationModule()
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

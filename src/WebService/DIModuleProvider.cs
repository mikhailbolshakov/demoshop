using DemoShop.Libs.DI;
using DemoShop.Organization.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService
{
    public static class DIModuleProvider
    {
        public static IEnumerable<IDIModule> Modules()
        {
            return new IDIModule[] 
            {
                new OrganizationModule()
            };
        }
    }
}

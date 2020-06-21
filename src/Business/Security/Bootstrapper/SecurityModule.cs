using DemoShop.Libs.DI;
using DemoShop.Security.ApplicationService;
using DemoShop.Security.DomainService;
using DemoShop.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.Bootstrapper
{
    public class SecurityModule : DIModuleBase
    {
        protected override IEnumerable<IDIComponent> Components()
        {
            return new IDIComponent[]
                    {
                        new SecurityApplicationComponent(),
                        new SecurityDomainComponent(),
                        new SecurityInfrastructureComponent()
                    };
    }
    }
}

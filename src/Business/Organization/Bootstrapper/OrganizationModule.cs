using DemoShop.Libs.DI;
using DemoShop.Organization.ApplicationService;
using DemoShop.Organization.DomainService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.Bootstrapper
{
    public class OrganizationModule : DIModuleBase
    {
        protected override IEnumerable<IDIComponent> Components()
        {
            return new IDIComponent[]
                    {
                        new OrganizationDomainComponent(),
                        new OrganizationApplicationComponent()
                    };
    }
    }
}

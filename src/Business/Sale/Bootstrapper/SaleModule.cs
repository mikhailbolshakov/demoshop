using DemoShop.Libs.DI;
using DemoShop.Sale.ApplicationService;
using DemoShop.Sale.DomainService;
using DemoShop.Sale.Infrastructure;
using System.Collections.Generic;

namespace DemoShop.Security.Bootstrapper
{
    public class SaleModule : DIModuleBase
    {
        protected override IEnumerable<IDIComponent> Components()
        {
            return new IDIComponent[]
                    {
                        new SaleApplicationComponent(),
                        new SaleDomainComponent(),
                        new SaleInfrastructureComponent()
                    };
    }
    }
}

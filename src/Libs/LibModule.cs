using DemoShop.Libs.DI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs
{
    public class LibModule : DIModuleBase
    {
        protected override IEnumerable<IDIComponent> Components()
        {
            return new IDIComponent[]
                    {
                        new LibPersistenceComponent()
                    };
    }
    }
}

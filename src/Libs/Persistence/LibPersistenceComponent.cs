using System;
using System.Collections.Generic;
using System.Text;
using DemoShop.Libs.DI;
using Microsoft.Extensions.DependencyInjection;
using DemoShop.Libs.Persistence.DbFactory;

namespace DemoShop.Libs
{

    public class LibPersistenceComponent : DIComponentBase
    {

        protected override void BindCustom(IServiceCollection services)
        {
            services.AddSingleton<DbFactory>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

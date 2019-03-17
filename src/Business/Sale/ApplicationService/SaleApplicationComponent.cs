using DemoShop.Libs.AutoMapper;
using DemoShop.Libs.DI;
using DemoShop.Sale.API.Product.shared.Service;
using DemoShop.Sale.ApplicationService.Products.shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.ApplicationService
{
    public class SaleApplicationComponent : DIComponentBase
    {

        protected override void BindCustom(IServiceCollection services)
        {
            services.AddTransient<IProductSharedService, ProductSharedService>();

            services.AddTransient<IAutoMapperInitializer, ProductSharedServiceMapperInitializer>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

using DemoShop.Libs.DI;
using DemoShop.Sale.Domain.Products.Service;
using DemoShop.Sale.DomainService.Products.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.DomainService
{
    public class SaleDomainComponent : DIComponentBase
    {
        protected override void BindCustom(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

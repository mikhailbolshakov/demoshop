using DemoShop.Libs.AutoMapper;
using DemoShop.Libs.DI;
using DemoShop.Sale.Domain.Products.Repository;
using DemoShop.Sale.Infrastructure.Products;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoShop.Sale.Infrastructure
{
    public class SaleInfrastructureComponent : DIComponentBase
    {
        protected override void BindCustom(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IAutoMapperInitializer, ProductRepositoryMapperInitializer>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

using AutoMapper;
using AutoMapper.Configuration;
using DemoShop.Libs.AutoMapper;
using DemoShop.Sale.Domain.Products;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.Infrastructure.Products
{
    public class ProductRepositoryMapperInitializer : IAutoMapperInitializer
    {
        public void Initialize(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, ProductBson>()
                .ForMember(
                    dest => dest.Details,
                    opt => opt.MapFrom(src => src.Details.ToString())
                );

            cfg.CreateMap<ProductBson, Product>()
                .ForMember(
                    dest => dest.Details,
                    opt => opt.MapFrom(src => JObject.Parse(src.Details))
                );
        }
    }

    public static class ProductRepositoryMapper
    {
        public static Product Map(ProductBson source) => Mapper.Map<ProductBson, Product>(source);
        public static ProductBson Map(Product source) => Mapper.Map<Product, ProductBson>(source);
    }
}

using AutoMapper;
using AutoMapper.Configuration;
using DemoShop.Libs.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using API = DemoShop.Sale.API.Product.shared.Dto;
using Domain = DemoShop.Sale.Domain.Products;


namespace DemoShop.Sale.ApplicationService.Products.shared
{
    public class ProductSharedServiceMapperInitializer : IAutoMapperInitializer
    {

        public void Initialize(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<API::AddProductRequest, Domain::Product>();
            cfg.CreateMap<API::Price, Domain::Price>();
        }
    }

    public static class ProductSharedServiceMapper
    {
        public static Domain::Product Map(API::AddProductRequest source) => Mapper.Map<API::AddProductRequest, Domain::Product>(source);
        public static Domain::Price Map(API::Price source) => Mapper.Map<API::Price, Domain::Price>(source);
    }

}

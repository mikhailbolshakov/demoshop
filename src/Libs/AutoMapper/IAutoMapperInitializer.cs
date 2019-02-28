using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.AutoMapper
{
    public interface IAutoMapperInitializer
    {
        void Initialize(MapperConfigurationExpression cfg);
    }
}

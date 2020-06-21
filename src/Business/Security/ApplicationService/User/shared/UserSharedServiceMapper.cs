using AutoMapper;
using AutoMapper.Configuration;
using DemoShop.Libs.AutoMapper;
using DemoShop.Security.API.User.shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using API = DemoShop.Security.API.User.shared.Dto;
using Domain = DemoShop.Security.Domain.User;

namespace DemoShop.Security.ApplicationService.User.shared
{
    public class UserSharedServiceMapperInitializer : IAutoMapperInitializer
    {

        public void Initialize(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<API::RegisterUserRequest, Domain::User>();
            cfg.CreateMap<Domain::User, API::User>();
        }
    }

    public static class UserSharedServiceMapper
    {
        public static Domain.User.User Map(API::RegisterUserRequest source) => Mapper.Map<API::RegisterUserRequest, Domain::User>(source);
        public static API::User Map(Domain::User source) => Mapper.Map<Domain::User, API::User>(source);
    }

}

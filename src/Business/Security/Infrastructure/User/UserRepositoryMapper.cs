using AutoMapper;
using AutoMapper.Configuration;
using DemoShop.Libs.AutoMapper;
using DemoShop.Security.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.Infrastructure.Users
{
    public class UserRepositoryMapperInitializer : IAutoMapperInitializer
    {
        public void Initialize(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserBson>();
            cfg.CreateMap<UserBson, User>();
        }
    }

    public static class UserRepositoryMapper
    {
        public static User Map(UserBson source) => Mapper.Map<UserBson, User>(source);
        public static UserBson Map(User source) => Mapper.Map<User, UserBson>(source);
    }
}

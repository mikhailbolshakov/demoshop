using DemoShop.Libs.AutoMapper;
using DemoShop.Libs.DI;
using DemoShop.Security.Domain.User.Repository;
using DemoShop.Security.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.Infrastructure
{
    public class SecurityInfrastructureComponent : DIComponentBase
    {
        protected override void BindCustom(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAutoMapperInitializer, UserRepositoryMapperInitializer>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

using DemoShop.Libs.DI;
using DemoShop.Security.Domain.User.Repository;
using DemoShop.Security.Infrastructure.User;
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
            services.AddScoped<IUserRepository, UserRepository>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

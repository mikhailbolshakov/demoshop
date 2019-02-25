using DemoShop.Libs.DI;
using DemoShop.Security.Domain.User.Service;
using DemoShop.Security.DomainService.User.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.DomainService
{
    public class SecurityDomainComponent : DIComponentBase
    {
        protected override void BindCustom(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

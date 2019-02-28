using DemoShop.Libs.AutoMapper;
using DemoShop.Libs.DI;
using DemoShop.Security.API.User.shared.Service;
using DemoShop.Security.ApplicationService.User.shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.ApplicationService
{
    public class SecurityApplicationComponent : DIComponentBase
    {

        protected override void BindCustom(IServiceCollection services)
        {
            services.AddScoped<IUserSharedService, UserSharedService>();
            services.AddScoped<IAutoMapperInitializer, UserSharedServiceMapperInitializer>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

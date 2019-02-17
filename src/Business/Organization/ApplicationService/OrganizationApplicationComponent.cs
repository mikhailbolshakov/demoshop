using DemoShop.Libs.DI;
using DemoShop.Organization.API;
using DemoShop.Organization.ApplicationService.Employee.shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.ApplicationService
{
    public class OrganizationApplicationComponent : DIComponentBase
    {

        protected override void BindCustom(IServiceCollection services)
        {
            services.AddScoped<IEmployeeSharedService, EmployeeSharedService>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

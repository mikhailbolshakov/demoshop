using DemoShop.Libs.DI;
using DemoShop.Organization.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.DomainService
{
    public class OrganizationDomainComponent : DIComponentBase
    {

        protected override void BindCustom(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        protected override void InitializeCustom(IServiceProvider provider)
        {
        }
    }
}

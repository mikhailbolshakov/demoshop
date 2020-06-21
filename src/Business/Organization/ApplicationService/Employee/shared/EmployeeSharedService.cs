using DemoShop.Organization.API;
using DemoShop.Organization.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.ApplicationService.Employee.shared
{
    public class EmployeeSharedService : IEmployeeSharedService
    {
        private readonly IEmployeeService _domainService;

        public EmployeeSharedService(IEmployeeService domainService)
        {
            _domainService = domainService;
        }

        EmployeeSharedDto IEmployeeSharedService.GetEmployee(string id)
        {
            var domainObj = _domainService.New(null);

            return new EmployeeSharedDto()
            {
                Id = domainObj.Id,
                FullName = domainObj.FullName,
                Email = domainObj.Email
            };
        }
    }
}

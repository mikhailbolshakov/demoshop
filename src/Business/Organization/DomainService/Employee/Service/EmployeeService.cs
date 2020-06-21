using DemoShop.Organization.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.DomainService
{
    public class EmployeeService : IEmployeeService
    {
        public Employee New(Employee emp)
        {
            return new Employee()
            {
                Id = Guid.NewGuid(),
                FullName = "Test",
                Email = "email@test.com"
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.API
{
    public interface IEmployeeSharedService
    {
        EmployeeSharedDto GetEmployee(string id);
    }
}

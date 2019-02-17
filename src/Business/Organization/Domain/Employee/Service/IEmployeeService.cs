using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.Domain
{
    /// <summary>
    /// Employee contract
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// creates a new employee
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>modified employee object</returns>
        Employee New(Employee emp);
    }
}

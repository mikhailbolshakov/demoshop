using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.API
{
    public class EmployeeSharedDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Employee full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Employee email
        /// </summary>
        public string Email { get; set; }
    }
}

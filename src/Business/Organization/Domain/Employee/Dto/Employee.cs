using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.Domain
{
    public class Employee
    {
        /// <summary>
        /// Employee unique identifier
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

        /// <summary>
        /// Employee position
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Link to organization unit
        /// </summary>
        public Guid OrganizationUnitId { get; set; }

    }
}

using DemoShop.Organization.Domen.OrganizationStructure.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.Domen.OrganizationStructure.Dto
{
    public class OrganizationUnit
    {
        /// <summary>
        /// organization unit unique identifier
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// organization unit type
        /// </summary>
        public OrganizationUnitTypeEnum Type { get; set; }

        /// <summary>
        /// organization unit name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// parent organization unit id
        /// it has null value for the head organization
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}

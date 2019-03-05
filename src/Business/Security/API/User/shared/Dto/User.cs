using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoShop.Security.API.User.shared.Dto
{
    public class User
    {
        /// <summary>
        /// user ID
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// an user name (must be unique)
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// user email (must be unique)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// user roles
        /// </summary>
        public List<string> Roles { get; set; }
    }
}

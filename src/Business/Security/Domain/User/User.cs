using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.Domain.User
{
    public class User
    {
        /// <summary>
        /// user ID
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// an unique user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// user email
        /// </summary>
        public string Email { get; set; }


    }
}

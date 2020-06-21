using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoShop.Security.API.User.shared.Dto
{
    public class RegisterUserRequest
    {
        /// <summary>
        /// an user name (must be unique)
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// user email (must be unique)
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}

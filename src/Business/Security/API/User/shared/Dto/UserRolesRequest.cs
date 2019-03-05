using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.API.User.shared.Dto
{
    public class UserRolesRequest
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}

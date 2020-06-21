using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.Infrastructure.Users
{
    public class UserBson
    {
        [BsonId]
        public Guid? UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public List<string> Roles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.Domain.User.Consts
{
    public static class RolesConsts
    {
        public const string ADMIN = "admin";
        public const string CUSTOMER = "customer";

        public static bool IsValid (string role)
        {
            return !string.IsNullOrEmpty(role) &&
                   (role.ToLower() == ADMIN || role.ToLower() == CUSTOMER); 
        }
    }
}

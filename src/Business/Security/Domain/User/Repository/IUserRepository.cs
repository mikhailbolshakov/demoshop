using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.Domain.User.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Create(User user);
    }
}

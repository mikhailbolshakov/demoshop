using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Security.Domain.User.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> Create(User user);
    }
}

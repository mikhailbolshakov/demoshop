using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Security.Domain.User.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>modified user object</returns>
        Task<User> CreateAsync(User user);

        /// <summary>
        /// retrieves an user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>user object or null if no user found</returns>
        Task<User> GetByIdAsync(Guid userId);

        /// <summary>
        /// updates existent user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> UpdateAsync(User user);

    }
}

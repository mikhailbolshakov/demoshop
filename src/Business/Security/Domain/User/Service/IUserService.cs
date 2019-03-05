using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Security.Domain.User.Service
{
    public interface IUserService
    {
        /// <summary>
        /// get user by Id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>user object</returns>
        Task<User> GetByIdAsync(Guid userId);

        /// <summary>
        /// register a new user
        /// </summary>
        /// <param name="user">user object</param>
        /// <returns>modified user object</returns>
        Task<User> RegisterUserAsync(User user);

        /// <summary>
        /// grants roles to the user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <param name="roles">roles to be granted</param>
        /// <returns>user with granted roles</returns>
        Task<User> Grant(Guid userId, List<string> roles);

        /// <summary>
        /// revokes roles from the user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <param name="roles">roles</param>
        /// <returns>user with revoked roles</returns>
        Task<User> Revoke(Guid userId, List<string> roles);

    }
}

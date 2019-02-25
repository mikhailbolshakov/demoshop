using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.Domain.User.Service
{
    public interface IUserService
    {
        /// <summary>
        /// get user by Id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>user object</returns>
        User GetById(Guid userId);

        /// <summary>
        /// if user id is empty, creates a new user
        /// otherwise updates an existent one
        /// </summary>
        /// <param name="user">user object</param>
        /// <returns>modified user object</returns>
        User CreateUpdate(User user);

    }
}

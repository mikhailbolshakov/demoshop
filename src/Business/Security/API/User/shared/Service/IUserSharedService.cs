using DemoShop.Security.API.User.shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Security.API.User.shared.Service
{
    public interface IUserSharedService
    {
        /// <summary>
        /// register a new user
        /// </summary>
        /// <param name="user">user request</param>
        /// <returns>user object</returns>
        Task<Dto.User> RegisterUserAsync(RegisterUserRequest user);

        /// <summary>
        /// get user's profile
        /// </summary>
        /// <returns>user object</returns>
        Task<Dto.User> GetUserAsync(string userId);

        /// <summary>
        /// grants an user with given roles
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>user object</returns>
        Task<Dto.User> GrantAsync(UserRolesRequest request);

        /// <summary>
        /// revokes an user from given roles
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>user object</returns>
        Task<Dto.User> RevokeAsync(UserRolesRequest request);

    }
}

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
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Dto.User> RegisterUserAsync(Dto.User user);
    }
}

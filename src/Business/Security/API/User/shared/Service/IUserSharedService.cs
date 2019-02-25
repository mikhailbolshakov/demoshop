using DemoShop.Security.API.User.shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.API.User.shared.Service
{
    public interface IUserSharedService
    {
        /// <summary>
        /// creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        UserSharedDto CreateUser(UserSharedDto user);
    }
}

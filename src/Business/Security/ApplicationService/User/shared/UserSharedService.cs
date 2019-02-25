using DemoShop.Security.API.User.shared.Dto;
using DemoShop.Security.API.User.shared.Service;
using DemoShop.Security.Domain.User.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.ApplicationService.User.shared
{
    public class UserSharedService : IUserSharedService
    {

        #region private fields

        private readonly IUserService _userService;

        #endregion 

        #region ctor

        public UserSharedService(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region IUserSharedService

        public UserSharedDto CreateUser(UserSharedDto user)
        {

            // TODO: Automapper
            var domainUser = new Domain.User.User()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
            };

            var modifiedDomainUser = _userService.CreateUpdate(domainUser);

            var modifiedUser = new UserSharedDto()
            {
                UserId = modifiedDomainUser.UserId,
                UserName = modifiedDomainUser.UserName,
                Email = modifiedDomainUser.Email,
                Password = modifiedDomainUser.Password
            };

            return modifiedUser;

        }

        #endregion 
    }
}

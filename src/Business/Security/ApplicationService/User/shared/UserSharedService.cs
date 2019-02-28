﻿using DemoShop.Libs.AutoMapper;
using DemoShop.Security.API.User.shared.Dto;
using DemoShop.Security.API.User.shared.Service;
using DemoShop.Security.Domain.User.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<API.User.shared.Dto.User> RegisterUserAsync(API.User.shared.Dto.User user)
        {

            // map to domain object
            var domainObj = UserSharedServiceMapper.Map(user);

            var modifiedDomainObj = await _userService.RegisterUserAsync(domainObj);

            var modifiedObj = UserSharedServiceMapper.Map(modifiedDomainObj);

            return modifiedObj;

        }

        #endregion 
    }
}

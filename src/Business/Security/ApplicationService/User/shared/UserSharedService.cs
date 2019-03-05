using DemoShop.Libs.AutoMapper;
using DemoShop.Libs.Extensions.strings;
using DemoShop.Libs.WebApi.ExceptionHandling.CustomExceptions;
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

        #region private methods

        #endregion 

        #region IUserSharedService

        public async Task<API.User.shared.Dto.User> RegisterUserAsync(RegisterUserRequest user)
        {

            // map to domain object
            var domainObj = UserSharedServiceMapper.Map(user);

            // execute domain service
            var modifiedDomainObj = await _userService.RegisterUserAsync(domainObj);

            // map back from domain result
            var resp = UserSharedServiceMapper.Map(modifiedDomainObj);

            return resp;

        }

        public async Task<API.User.shared.Dto.User> GetUserAsync(string userId)
        {
            // get domain object
            var domainObj = await _userService.GetByIdAsync(userId.ToGuid());

            // map to shared object
            var resp = UserSharedServiceMapper.Map(domainObj);

            return resp;
        }

        public async Task<API.User.shared.Dto.User> GrantAsync(UserRolesRequest request)
        {
            // call domain logic
            var domainObj = await _userService.Grant(request.UserId.ToGuid(), request.Roles);

            // map to shared object
            var resp = UserSharedServiceMapper.Map(domainObj);

            return resp;
        }

        public async Task<API.User.shared.Dto.User> RevokeAsync(UserRolesRequest request)
        {
            // call domain logic
            var domainObj = await _userService.Revoke(request.UserId.ToGuid(), request.Roles);

            // map to shared object
            var resp = UserSharedServiceMapper.Map(domainObj);

            return resp;
        }

        #endregion
    }
}

using DemoShop.Security.API.User.shared.Dto;
using DemoShop.Security.API.User.shared.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Security.WebApi.User.shared
{
    [ApiController, Authorize, Route("api/security/shared/user")]
    public class UserSharedServiceController : ControllerBase, IUserSharedService
    {

        private readonly IUserSharedService _service;

        public UserSharedServiceController(IUserSharedService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<API.User.shared.Dto.User> RegisterUserAsync(API.User.shared.Dto.User user)
        {
            return await _service.RegisterUserAsync(user);
        }

    }
}

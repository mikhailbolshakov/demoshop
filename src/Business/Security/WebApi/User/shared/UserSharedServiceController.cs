using DemoShop.Security.API.User.shared.Dto;
using DemoShop.Security.API.User.shared.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.WebApi.User.shared
{
    [ApiController, Route("api/security/shared/user")]
    [Authorize]
    public class UserSharedServiceController : ControllerBase, IUserSharedService
    {

        private readonly IUserSharedService _service;

        public UserSharedServiceController(IUserSharedService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public UserSharedDto CreateUser(UserSharedDto user)
        {
            return _service.CreateUser(user);
        }

    }
}

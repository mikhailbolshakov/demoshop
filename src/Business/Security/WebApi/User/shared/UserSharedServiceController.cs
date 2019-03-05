using DemoShop.Libs.WebApi;
using DemoShop.Security.API.User.shared.Dto;
using DemoShop.Security.API.User.shared.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Security.WebApi.User.shared
{
    [ApiController, Authorize, Route("api/security/shared/user")]
    public class UserSharedServiceController : DsControllerBase
    {

        private readonly IUserSharedService _service;

        public UserSharedServiceController(IUserSharedService service)
        {
            _service = service;
        }

        [HttpGet("get-user/{userId}")]
        public async Task<ActionResult<API.User.shared.Dto.User>> GetUserAsync(string userId)
        {
            return await _service.GetUserAsync(userId);
        }

        [HttpGet("get-current-user")]
        public async Task<ActionResult<API.User.shared.Dto.User>> GetCurrentUserAsync()
        {
            return await GetUserAsync(ClaimByType("user_id"));
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<API.User.shared.Dto.User> RegisterUserAsync(RegisterUserRequest userRequest)
        {
            return await _service.RegisterUserAsync(userRequest);
        }
        
        [HttpPost("grant"), Authorize("Admin")]
        public async Task<API.User.shared.Dto.User> GrantAsync(UserRolesRequest request)
        {
            return await _service.GrantAsync(request);
        }

        [HttpPost("revoke"), Authorize("Admin")]
        public async Task<API.User.shared.Dto.User> RevokeAsync(UserRolesRequest request)
        {
            return await _service.RevokeAsync(request);
        }

    }
}

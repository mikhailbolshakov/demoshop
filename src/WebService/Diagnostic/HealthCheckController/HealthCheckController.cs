using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebService.Diagnostic.HealthCheckController
{
    
    [ApiController, Route("diagnostic/health-check")]
    public class HealthCheckController : ControllerBase
    {
        [HttpPost("auth"), Authorize]
        public StatusCodeResult CheckAuth()
        {
            return new OkResult();
        }

        [HttpPost("no-auth"), AllowAnonymous]
        public StatusCodeResult CheckNoAuth()
        {
            return new OkResult();
        }
    }
    
}

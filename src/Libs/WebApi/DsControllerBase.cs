using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoShop.Libs.WebApi
{
    public abstract class DsControllerBase : ControllerBase
    {
        protected string ClaimByType(string type)
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == type);

            return claim != null
                ? claim.Value
                : throw new Exception($"Claim with type {type} isn't found");
        }

    }
}

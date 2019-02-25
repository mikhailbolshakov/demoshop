using DemoShop.Organization.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Organization.WebApi.Employee.shared
{
    [ApiController, Route("api/shared/employee")]
    [Authorize]
    public class EmployeeController : ControllerBase, IEmployeeSharedService
    {

        private readonly IEmployeeSharedService _service;

        public EmployeeController(IEmployeeSharedService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public EmployeeSharedDto GetEmployee(string id)
        {
            return _service.GetEmployee(id);
        }
    }
}

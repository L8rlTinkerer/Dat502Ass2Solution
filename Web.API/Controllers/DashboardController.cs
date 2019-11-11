using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Contracts;

namespace Web.API.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public DashboardController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            // TODO: Check the user exists

            // get the user type
            var userType = _repository.SystemUser.GetUserType(userId);

            // Based of user type get the correct dashboard
            switch (userType)
            {
                case 4:
                    {
                        var dashboard = _repository.DashboardRepository.GetClientDashboard(userId);
                        // TODO: check dashboard isn't empty ore null'
                        return Ok(dashboard);
                    }
            }

            return BadRequest();
        }


    }
}

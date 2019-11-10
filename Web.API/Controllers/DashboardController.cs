using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        /*
        // GET: api/Dashboard/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var obj = JObject.Parse(request);
            int userType = (int)obj["SystemUserTypeNo"];

            var user = _userFactory.CreateUser(userType, request);

            if (user == null)
            {
                return BadRequest("User already exists");
            }

            _repository.UserRepository.CreateUser(user);


            try
            {
                _repository.Save();
            }
            catch (Exception)
            {
                return Ok(
                new RegisterResponseDTO
                {
                    Success = false,
                    Message = "User not created."
                }
                );
            }

            return Ok(
                new RegisterResponseDTO
                {
                    Success = true,
                    Message = "User created successfully"
                }
            );
        }
        */

       
    }
}

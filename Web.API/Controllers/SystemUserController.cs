using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects;
using Web.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.API
{
    [Route("api/systemuser")]
    public class SystemUserController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IUserFactory _userFactory;

        public SystemUserController(IRepositoryWrapper repository, IUserFactory userFactory)
        {
            _repository = repository;
            _userFactory = userFactory;
        }


        [HttpGet]
        public IActionResult GetAllSystemUsers()
        {
            try
            {
                var systemUsers = _repository.SystemUser.GetAllSystemUsers();

                return Ok(systemUsers);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<controller>
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginDTO userLogin)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var response = _repository.SystemUser.Login(userLogin);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);

        }


        
        // POST api/<controller>
        [HttpPost("register")]
        public IActionResult Register([FromBody] string request)
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
            _repository.Save();

            return Ok(
                new RegisterResponseDTO
                {
                    Success = true,
                    Message = "User created successfully",
                    JWT = null
                }
            );

        }
        




        /*
        // POST api/<controller>
        [HttpPost("register-client")]
        public IActionResult RegisterClient([FromBody]RegisterBaseUserDTO userRego)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var user = _repository.SystemUser.Register(userRego); // checks if user exists already

            if (user == null)
            {
                return BadRequest("User already exists");
            }

            _repository.SystemUser.Create(user);

            _repository.Save();

            var clientDto = new RegisterClientDTO
            {
                SystemUserNo = user.SystemUserNo,
                PreferredAccomodationType = userRego.PreferredAccomodationType,
                MaximumRent = userRego.MaximumRent,
                IsActive = userRego.IsActive
            };

            var client = _repository.Client.RegisterClient(clientDto);

            _repository.Client.Create(client);

            _repository.Save();

            return Ok(
                new RegisterResponseDTO
                {
                    Success = true,
                    Message = "User created successfully",
                    JWT = null
                }
            );

        }

        */


        /*
            var user = _repository.SystemUser.GetRegisteredClientSystemUser(userRego);

                if (user == null)
                {
                    return BadRequest("User does not exist");
                }

                var client = _repository.Client.RegisterClient(userRego);

                if (client == null)
                {
                    return BadRequest("Client already exists");
                }

                _repository.Client.Create(client);

                _repository.Save();
                
            }

            //RegisterClient(userRego);
        */




        /*
        private IActionResult RegisterClient([FromBody]RegisterSystemUserDTO userRego)
        {
            var user = _repository.SystemUser.GetRegisteredClientSystemUser(userRego);

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var client = _repository.Client.RegisterClient(userRego);

            if (client == null)
            {
                return BadRequest("Client already exists");
            }

            _repository.Client.Create(client);

            _repository.Save();

            return Ok(
                new RegisterResponseDTO
                {
                    Success = true,
                    Message = "Client created successfully",
                    JWT = null
                }
            );
            
        }
        */

        /*
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}

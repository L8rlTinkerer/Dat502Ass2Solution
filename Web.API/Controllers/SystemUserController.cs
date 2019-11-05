using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Contracts;
using Web.Entities.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.API
{
    [Route("api/systemuser")]
    public class SystemUserController : Controller
    {
        private IRepositoryWrapper _repository;

        public SystemUserController(IRepositoryWrapper repository)
        {
            _repository = repository;
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
        public IActionResult Register([FromBody]RegisterDTO userRego)
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
            
            if (userRego.SystemUserType == 4)
            {
                
                //var client = _repository.Client.RegisterClient
            }



            return Ok(
                new RegisterResponseDTO
                {
                    Success = true,
                    Message = "User created successfully",
                    JWT = null
                }
            );
               

        }

        public IActionResult RegisterClient([FromBody]RegisterDTO userRego)
        {
            var user = _repository.SystemUser.GetRegisteredClientSystemUser(userRego);

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            _repository.SystemUser.RegisterClient(userRego);

            



        }

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

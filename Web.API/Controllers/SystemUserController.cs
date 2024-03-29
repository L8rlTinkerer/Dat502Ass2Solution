﻿using System;
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
    [ApiController]
    public class SystemUserController : ControllerBase
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

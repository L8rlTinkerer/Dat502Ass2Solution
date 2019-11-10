using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects.BranchDTOs;

namespace Web.API.Controllers
{
    [Route("api/branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public BranchController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // POST: api/ClientBranchRegister
        [HttpPost("addbranch")]
        public IActionResult AddBranch([FromBody] string request)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var obj = JObject.Parse(request);
            var newBranch = JsonConvert.DeserializeObject<AddBranchDTO>(request);
            
            var branch = _repository.BranchRepository.AddBranch(newBranch);
            
            if (branch == null)
            {
                return BadRequest("Branch already exists");
            }

            _repository.BranchRepository.CreateBranch(branch);

            try
            {
                _repository.Save();
            }
            catch (Exception err)
            {
                return Ok(
                    new AddBranchResponseDTO
                    {
                        Success = false,
                        Message = "Branch was not added" + err.InnerException.Message
                    }
                );
            }


            return Ok(
                new AddBranchResponseDTO
                {
                    Success = true,
                    Message = "Branch added successfully"
                }
            );
        }

        /*
        // GET: api/Branch
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Branch/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT: api/Branch/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}

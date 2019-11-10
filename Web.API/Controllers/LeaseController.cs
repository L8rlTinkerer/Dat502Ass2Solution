using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects.LeaseDTOs;

namespace Web.API.Controllers
{
    [Route("api/lease")]
    [ApiController]
    public class LeaseController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public LeaseController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }


        
        [HttpPost("addlease")]
        public IActionResult AddLease([FromBody] string request)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var obj = JObject.Parse(request);
            var newLease = JsonConvert.DeserializeObject<CreateLeaseDTO>(request);

            var lease = _repository.LeaseRepository.AddLease(newLease);

            if (lease == null)
            {
                return BadRequest("Lease exists.");
            }

            _repository.LeaseRepository.CreateLease(lease);

            try
            {
                _repository.Save();
            }
            catch (Exception)
            {
                return Ok(
                    new CreateLeaseResponseDTO
                    {
                        Success = false,
                        Message = "Lease was not added"
                    }
                );
            }

            return Ok(
                new CreateLeaseResponseDTO
                {
                    Success = true,
                    Message = "Lease added successfully"
                });
        }
        
        

        /*
         
        // GET: api/Lease
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lease/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Lease
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Lease/5
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

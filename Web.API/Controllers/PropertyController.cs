using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects.ClientPropertiesDTOs;
using Web.Entities.DataTransferObjects.PropertyDTOs;
using Web.Entities.Models;

namespace Web.API.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public PropertyController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }


        //[HttpGet("/client-properties/{id}", Name = "Client-properties")]
        //public string GetClientProperties([FromBody] ClientPropertiesDTO clientPropertiesDTO)
        //{
        //    var regos = _repository.ClientBranchRego.GetAllRegistrationsForOneClient(clientPropertiesDTO);

        //    foreach (TblRegistration rego in regos)
        //    {

        //    }
        //    //var properties = 

        //    return "value";
        //}


        // POST: api/Property
        [HttpPost("addproperty")]
        public IActionResult AddProperty([FromBody] string request)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var obj = JObject.Parse(request);
            var newProperty = JsonConvert.DeserializeObject<AddAPropertyDTO>(request);

            var property = _repository.Property.AddProperty(newProperty);

            if (property == null)
            {
                return BadRequest("Property already exists");
            }


            _repository.Property.CreateProperty(property);
            _repository.Save();

            return Ok(
                new AddAPropertyResponseDTO
                {
                    Success = true,
                    Message = "Property added successfully",
                    JWT = null
                }
            );
        }


        /*
         
        // GET: api/Property
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Property/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT: api/Property/5
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

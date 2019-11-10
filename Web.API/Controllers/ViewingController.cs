using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects.ViewingDTOs;

namespace Web.API.Controllers
{
    [Route("api/viewing")]
    [ApiController]
    public class ViewingController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public ViewingController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }



        [HttpPost("addviewing")]
        public IActionResult AddViewing([FromBody] string request)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var obj = JObject.Parse(request);
            var newAdvert = JsonConvert.DeserializeObject<CreateViewingDTO>(request);

            var viewing = _repository.ViewingRepository.AddViewing(newAdvert);

            if (viewing == null)
            {
                return BadRequest("Viewing exists.");
            }

            _repository.ViewingRepository.CreateViewing(viewing);

            try
            {
                _repository.Save();
            }
            catch (Exception)
            {
                return Ok(
                    new CreateViewingResponseDTO
                    {
                        Success = false,
                        Message = "Viewing was not added"
                    }
                );
            }

            return Ok(
                new CreateViewingResponseDTO
                {
                    Success = true,
                    Message = "Viewing added successfully"
                });
        }

        /*
        // GET: api/Viewing
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Viewing/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Viewing
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Viewing/5
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

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Web.Contracts;
using Web.Entities.DataTransferObjects.AdvertDTOs;
using Web.Entities.DataTransferObjects.PropertyDTOs;

namespace Web.API.Controllers
{
    [Route("api/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {

        private readonly IRepositoryWrapper _repository;

        public AdvertController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpPost("addadvert")]
        public IActionResult AddProperty([FromBody] string request)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var obj = JObject.Parse(request);
            var newAdvert = JsonConvert.DeserializeObject<CreateAdvertDTO>(request);
            
            var advert = _repository.AdvertRepository.AddAdvert(newAdvert);

            if (advert == null)
            {
                return BadRequest("Property does not exist.");
            }

            _repository.AdvertRepository.CreateAdvert(advert);

            try
            {
                _repository.Save();
            }
            catch (Exception)
            {
                return Ok(
                    new CreateAdvertResponseDTO
                    {
                        Success = false,
                        Message = "Advert was not added"
                    }
                );
            }

            return Ok(
                new CreateAdvertResponseDTO
                {
                    Success = true,
                    Message = "Advert added successfully"
                });
            
        }
    }
}
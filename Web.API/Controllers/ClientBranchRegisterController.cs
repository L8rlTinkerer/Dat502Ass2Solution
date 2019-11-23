using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects.BranchRegistrationDTOs;
using Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs;

namespace Web.API.Controllers
{
    [Route("api/clientbranchregister")]
    [ApiController]
    public class ClientBranchRegisterController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public ClientBranchRegisterController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        

        // POST: api/ClientBranchRegister
        [HttpPost("addclientbranchrego")]
        public IActionResult AddClientBranchRego([FromBody] string request)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var obj = JObject.Parse(request);
            var newRequest = JsonConvert.DeserializeObject<InitalRequestToAddCBRDTO>(request);

            // check staff memeber is registered with the company (is a system user)
            var staffSystemUser = _repository.SystemUser.GetSystemUserById(newRequest.SystemUserNo);
            if (staffSystemUser == null)
            {
                return BadRequest("staffSystemUser does not exist");
            }


            // retrieve staffNo
            var staff = _repository.StaffRepository.GetStaffNo(newRequest.SystemUserNo);
            if (staff == null)
            {
                return BadRequest("staffSystemUser does not exist");
            }


            // check branchNo
            var branch = _repository.BranchRepository.CheckBranchNo(newRequest.BranchNo);
            if (branch == null)
            {
                return BadRequest("Branch does not exist");
            }

            // check client is registered with the company (is a system user)
            var clientSystemUser = _repository.SystemUser.GetUserByUserNameAndUserType(newRequest.UserName);
            if (clientSystemUser == null)
            {
                return BadRequest("clientSystemUser does not exist");
            }


            // check client exists and retrieve clientNo
            var client = _repository.ClientRepository.GetClientNo(clientSystemUser.SystemUserNo);
            if (client == null)
            {
                return BadRequest("Client does not exist");
            }

            AddClientBranchRegisterDTO newRego = _repository.ClientBranchRego.AddNewCBR(staff, client, branch);            

            var rego = _repository.ClientBranchRego.AddRegistration(newRego);

            if (rego == null)
            {
                return BadRequest("Registration already exists");
            }

            _repository.ClientBranchRego.CreateRegistration(rego);

            try
            {
                _repository.Save();
            }
            catch (Exception)
            {
                return Ok(
                    new AddClientBranchRegisterResponseDTO
                    {
                        Success = false,
                        Message = "Registration was not added"
                    }
                );
            }
            

            return Ok(
                new AddClientBranchRegisterResponseDTO
                {
                    Success = true,
                    Message = "Registration added successfully"
                }
            );
        }


        /*
          
        // GET: api/ClientBranchRegister
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ClientBranchRegister/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT: api/ClientBranchRegister/5
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

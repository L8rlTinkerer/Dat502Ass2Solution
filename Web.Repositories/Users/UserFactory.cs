using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Repositories.Users
{

    public class UserFactory : IUserFactory
    {

        private readonly IRepositoryWrapper _repo;

        public UserFactory(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        
        public TblSystemUser CreateUser(int userType, string jsonRequest)
        {
            
            switch (userType)
            {
                case 1:
                    {
                        var assistant = JsonConvert.DeserializeObject<RegisterStaffMemberDTO>(jsonRequest);
                        return _repo.UserRepository.Register(assistant);
                    }
                case 2:
                    {
                        var supervisor = JsonConvert.DeserializeObject<RegisterStaffMemberDTO>(jsonRequest);
                        return _repo.UserRepository.Register(supervisor);
                    }
                case 3:
                    {
                        var manager = JsonConvert.DeserializeObject<RegisterStaffMemberDTO>(jsonRequest);
                        return _repo.UserRepository.Register(manager);
                    }
                case 4:
                    {
                        var client = JsonConvert.DeserializeObject<RegisterClientDTO>(jsonRequest);
                        return _repo.UserRepository.Register(client);
                    }
                case 5:
                    {
                        var owner = JsonConvert.DeserializeObject<RegisterOwnerDTO>(jsonRequest);
                        return _repo.UserRepository.Register(owner);
                    }
            }

            return null;
        }
        


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;

namespace Web.Contracts
{
    public interface IRepositoryWrapper
    {
        ISystemUserRepository SystemUser { get; }
        IClientRepository Client { get; }
        IUserRepository<RegisterBaseUserDTO> UserRepository { get; }
        void Save();
    }
}

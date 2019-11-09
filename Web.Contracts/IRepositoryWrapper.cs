using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs;
using Web.Entities.DataTransferObjects.PropertyDTOs;

namespace Web.Contracts
{
    public interface IRepositoryWrapper
    {
        IPropertyRepository<AddAPropertyDTO> Property { get; }
        ISystemUserRepository SystemUser { get; }
        IClientRepository Client { get; }
        IUserRepository<RegisterBaseUserDTO> UserRepository { get; }
        IClientBranchRegisterRepository<ClientBranchRegisterBaseDTO> ClientBranchRego { get; }

        void Save();
    }
}

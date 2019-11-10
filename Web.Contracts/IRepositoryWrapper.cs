using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.DataTransferObjects.AdvertDTOs;
using Web.Entities.DataTransferObjects.BranchDTOs;
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
        IBranchRepository<BranchBaseDTO> BranchRepository { get; }
        IAdvertRepository<AdvertBaseDTO> AdvertRepository { get; }

        void Save();
    }
}

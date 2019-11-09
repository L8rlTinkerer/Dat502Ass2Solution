using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface IClientBranchRegisterRepository<T> : IRepositoryBase<T>
    {
        IEnumerable<TblRegistration> GetAllRegistrations();

        TblRegistration AddRegistration<U>(U entity) where U : AddClientBranchRegisterDTO;
        void CreateRegistration<U>(U entity) where U : TblRegistration;

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface ISystemUserRepository : IRepositoryBase<TblSystemUser>
    {
        IEnumerable<TblSystemUser> GetAllSystemUsers();

        TblSystemUser GetRegisteredClientSystemUser(RegisterSystemUserDTO userRego);

        LoginResponseDTO Login(LoginDTO login);

        TblSystemUser Register(RegisterSystemUserDTO userRego);

        TblSystemUser RegisterClient(RegisterSystemUserDTO userRego);

        
    }




}

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

        LoginResponseDTO Login(LoginDTO login);
        TblSystemUser Register(RegisterClientDTO userRego);
        TblSystemUser GetRegisteredClientSystemUser(RegisterSystemUserDTO userRego);
        //TblClient RegisterClient(RegisterClientDTO clientRego);
        //TblStaff RegisterStaff(RegisterClientDTO userRego);
    }




}

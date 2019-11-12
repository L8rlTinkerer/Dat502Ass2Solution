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

        TblSystemUser GetSystemUser(RegisterBaseUserDTO userRego);

        LoginResponseDTO Login(LoginDTO login);

        int GetUserType(int userId);

        TblSystemUser GetUserByUserNameAndUserType(string userName);

        TblSystemUser GetSystemUserById(int userId);

    }




}

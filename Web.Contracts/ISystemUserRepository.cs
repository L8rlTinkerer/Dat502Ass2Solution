﻿using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface ISystemUserRepository : IRepositoryBase<TblSystemUser>
    {
        IEnumerable<TblSystemUser> GetAllSystemUsers();

        TblSystemUser GetRegisteredClientSystemUser(RegisterBaseUserDTO userRego);

        LoginResponseDTO Login(LoginDTO login);

        TblSystemUser Register(RegisterBaseUserDTO userRego);

        TblSystemUser RegisterClient(RegisterBaseUserDTO userRego);

        
    }




}

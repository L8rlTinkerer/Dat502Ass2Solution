using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface IUserFactory
    {
        TblSystemUser CreateUser(int userType, string jsonRequest);
    }


}

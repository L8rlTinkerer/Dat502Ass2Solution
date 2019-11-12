using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.Models;


namespace Web.Contracts
{
    public interface IStaffRepository
    {
        TblStaff GetStaffNo(int userId);
    }
}

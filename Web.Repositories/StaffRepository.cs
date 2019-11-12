using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Contracts;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly Dat502Ass2DBContext _dat502Ass2DBContext;

        public StaffRepository(Dat502Ass2DBContext dat502Ass2DBContext)
        {
            _dat502Ass2DBContext = dat502Ass2DBContext;
        }



        public TblStaff GetStaffNo(int userId)
        {
            var staff = _dat502Ass2DBContext.TblStaff.FirstOrDefault(x => x.SystemUserNo == userId);

            if (staff == null)
            {
                return null;
            }

            return staff;
        }

    }
}

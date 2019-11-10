using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects.BranchDTOs;
using Web.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Repositories
{
    public class BranchRepository<T> : RepositoryBase<T>, IBranchRepository<T> where T : BranchBaseDTO
    {
        public BranchRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {
   
        }

        public bool ConfirmManager<U>(U entity) where U : AddBranchDTO
        {
            /*
            // Linq version of select statement:
            var manager = from staff in TblStaff
                   join systemUser in TblSystemUser
                       on staff.SystemUserNo equals systemUser.SystemUserNo
                   join systemUserType in TblSystemUserType
                       on systemUser.SystemUserTypeNo equals systemUserType.SystemUserTypeNo
                   where systemUserType.SystemUserType == "manager"
                   select new {
                       TOP(1) 1
                   };
            */
            var manager = Dat502Ass2DBContext.TblStaff.FromSql($"select TOP(1) 1  from tbl_Staff s inner join tbl_SystemUser su on s.SystemUserNo = su.SystemUserNo inner join tbl_SystemUserType sut on su.SystemUserTypeNo = sut.SystemUserTypeNo where sut.SystemUserType = 'manager' and s.StaffNo = {entity.StaffNo}");
            if (manager == null)
            {
                return false;
            }

            return true;
        }

        public TblBranch AddBranch<U>(U entity) where U : AddBranchDTO
        {
            bool managerExists = ConfirmManager(entity);

            if (managerExists)
            {
                var branch = Dat502Ass2DBContext.TblBranch.Any(x =>
                                        x.AddressNoNavigation.StreetNumber == entity.AddressNoNavigation.StreetNumber &&
                                        x.AddressNoNavigation.StreetOrRoadName == entity.AddressNoNavigation.StreetOrRoadName &&
                                        x.AddressNoNavigation.CityOrTownName == entity.AddressNoNavigation.CityOrTownName &&
                                        x.AddressNoNavigation.PostCode == entity.AddressNoNavigation.PostCode
                                        );

                return branch ? null : entity.Map();
            }
            
            return null;
        }

        public void CreateBranch<U>(U entity) where U : TblBranch
        {
            Dat502Ass2DBContext.TblBranch.Add(entity);
        }

        public IEnumerable<TblBranch> GetAllRegistrations()
        {
            throw new NotImplementedException();
        }
    }
}

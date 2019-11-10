using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects.LeaseDTOs;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class LeaseRepository<T> : RepositoryBase<T>, ILeaseRepository<T> where T : LeaseBaseDTO
    {

        private readonly Dat502Ass2DBContext _context;

        public LeaseRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {
            _context = dat502Ass2DBContext;
        }

        public TblLease AddLease<U>(U entity) where U : CreateLeaseDTO
        {
            // check if lease exists
            var lease = _context.TblLease.FromSql($"select l.LeaseNo from tbl_Lease l inner join tbl_LeaseType lt on l.LeaseTypeNo = lt.LeaseTypeNo where l.PropertyNo = {entity.PropertyNo} AND (l.StartDate between {entity.StartDate} and {entity.EndDate} or l.EndDate between {entity.StartDate} and {entity.EndDate})").Any(); //.ToList();
            
            if (lease)
            {
                return null;
            }
            var newLease = entity.Map();

            return newLease;
            
          
        }
        
        public void CreateLease<U>(U entity) where U : TblLease
        {
            Dat502Ass2DBContext.TblLease.Add(entity);
        }
        
    }
}

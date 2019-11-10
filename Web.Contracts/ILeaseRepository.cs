using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects.LeaseDTOs;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface ILeaseRepository<T> : IRepositoryBase<T>
    {
        TblLease AddLease<U>(U entity) where U : CreateLeaseDTO;
        void CreateLease<U>(U entity) where U : TblLease;
        
    }
}

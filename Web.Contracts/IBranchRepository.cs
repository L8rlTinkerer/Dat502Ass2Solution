using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects.BranchDTOs;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface IBranchRepository<T> : IRepositoryBase<T>
    {
        IEnumerable<TblBranch> GetAllRegistrations();

        bool ConfirmManager<U>(U entity) where U : AddBranchDTO;
        TblBranch AddBranch<U>(U entity) where U : AddBranchDTO;
        void CreateBranch<U>(U entity) where U : TblBranch;

        TblBranch CheckBranchNo(int branchId);
    }
}

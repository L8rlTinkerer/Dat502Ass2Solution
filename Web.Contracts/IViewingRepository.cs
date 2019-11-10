using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects.ViewingDTOs;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface IViewingRepository<T> : IRepositoryBase<T>
    {
        TblViewing AddViewing<U>(U entity) where U : CreateViewingDTO;
        void CreateViewing<U>(U entity) where U : TblViewing;

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface IClientRepository : IRepositoryBase<TblClient>
    {
        IEnumerable<TblClient> GetAllClients();

        

    }
}

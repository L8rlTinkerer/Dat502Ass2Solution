using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects;
using Web.Entities.Mappers;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class ClientRepository : RepositoryBase<TblClient>, IClientRepository
    {
        private readonly Dat502Ass2DBContext _dat502Ass2DBContext;

        public ClientRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {
            _dat502Ass2DBContext = dat502Ass2DBContext;
        }

        public IEnumerable<TblClient> GetAllClients()
        {
            return FindAll()
                .OrderBy(ct => ct.ClientNo)
                .ToList();

        }


        public TblClient GetClientNo(int userId)
        {
            var client = _dat502Ass2DBContext.TblClient.FirstOrDefault(x => x.SystemUserNo == userId);

            if (client == null)
            {
                return null;
            }

            return client;
        }


    }
}

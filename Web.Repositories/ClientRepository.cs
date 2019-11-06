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
        public ClientRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {

        }

        public IEnumerable<TblClient> GetAllClients()
        {
            return FindAll()
                .OrderBy(ct => ct.ClientNo)
                .ToList();

        }

        public TblClient RegisterClient(RegisterClientDTO clientRego)
        {

            var client = Dat502Ass2DBContext.TblClient.Any(x => x.SystemUserNo == clientRego.SystemUserNo);
            

            return client ? null : RegisterResponseToClientMapper.Map(clientRego);
        }
    }
}

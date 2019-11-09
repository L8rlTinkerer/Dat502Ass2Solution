using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class ClientBranchRegisterRepository<T> : RepositoryBase<T>, IClientBranchRegisterRepository<T> where T : ClientBranchRegisterBaseDTO
    {
        public ClientBranchRegisterRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {

        }

        public TblRegistration AddRegistration<U>(U entity) where U: AddClientBranchRegisterDTO
        {
            var registration = Dat502Ass2DBContext.TblRegistration.Any(x =>
                                            x.ClientNo == entity.ClientNo &&
                                            x.BranchNo == entity.BranchNo
                                            );

            return registration ? null : entity.Map();
        }

        public void CreateRegistration<U>(U entity) where U : TblRegistration
        {
            Dat502Ass2DBContext.TblRegistration.Add(entity);
        }

        public IEnumerable<TblRegistration> GetAllRegistrations()
        {
            throw new NotImplementedException();
        }
    }
}

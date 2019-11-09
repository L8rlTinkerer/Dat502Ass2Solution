using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class UserRepository<T> : RepositoryBase<T>, IUserRepository<T> where T: RegisterBaseUserDTO
    {

        public UserRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {
            
        }

        public TblSystemUser Register(T entity)
        {
            var user = Dat502Ass2DBContext.TblSystemUser.Any(x => x.UserName == entity.UserName);

            return user ? null : entity.Map();
        }

        public void CreateUser<U>(U entity) where U : TblSystemUser
        {
            Dat502Ass2DBContext.TblSystemUser.Add(entity);
        }



    }
}

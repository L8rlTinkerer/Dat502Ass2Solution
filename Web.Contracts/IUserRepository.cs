using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface IUserRepository<T> : IRepositoryBase<T>
    {
        TblSystemUser Register(T entity);
        void CreateUser<U>(U entity) where U : TblSystemUser;
    }
}

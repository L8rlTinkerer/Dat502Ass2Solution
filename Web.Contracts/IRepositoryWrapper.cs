using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Contracts
{
    public interface IRepositoryWrapper
    {
        ISystemUserRepository SystemUser { get; }
        IClientRepository Client { get; }
        void Save();
    }
}

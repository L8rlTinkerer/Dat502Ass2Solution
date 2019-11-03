using System;
using System.Collections.Generic;
using System.Text;
using Web.Contracts;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private Dat502Ass2DBContext _repoContext;
        private ISystemUserRepository _systemUser;

        public ISystemUserRepository SystemUser
        {
            get
            {
                if (_systemUser == null)
                {
                    _systemUser = new SystemUserRepository(_repoContext);
                }

                return _systemUser;
            }
        }

       

        public RepositoryWrapper(Dat502Ass2DBContext dat502Ass2DBContext)
        {
            _repoContext = dat502Ass2DBContext;
        }

        public bool Save()
        {
            return _repoContext.SaveChanges() > 0;
            
        }
    }
}

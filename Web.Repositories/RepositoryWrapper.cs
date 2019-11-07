﻿using System;
using System.Collections.Generic;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private Dat502Ass2DBContext _repoContext;
        private ISystemUserRepository _systemUser;
        private IClientRepository _client;
        private IUserRepository<RegisterBaseUserDTO> _userRepository; 

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

       public IClientRepository Client
       {
            get
            {
                if (_client == null)
                {
                    _client = new ClientRepository(_repoContext);
                }

                return _client;
            }
       }

       public IUserRepository<RegisterBaseUserDTO> UserRepository
       {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository<RegisterBaseUserDTO>(_repoContext);
                }

                return _userRepository;
            }
       } 

        public RepositoryWrapper(Dat502Ass2DBContext dat502Ass2DBContext)
        {
            _repoContext = dat502Ass2DBContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
            
        }
    }
}

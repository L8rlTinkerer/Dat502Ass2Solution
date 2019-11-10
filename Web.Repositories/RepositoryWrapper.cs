using System;
using System.Collections.Generic;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects;
using Web.Entities.DataTransferObjects.AdvertDTOs;
using Web.Entities.DataTransferObjects.BranchDTOs;
using Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs;
using Web.Entities.DataTransferObjects.LeaseDTOs;
using Web.Entities.DataTransferObjects.PropertyDTOs;
using Web.Entities.DataTransferObjects.ViewingDTOs;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private Dat502Ass2DBContext _repoContext;
        private ISystemUserRepository _systemUser;
        private IClientRepository _client;
        private IPropertyRepository<AddAPropertyDTO> _property;
        private IUserRepository<RegisterBaseUserDTO> _userRepository;
        private IClientBranchRegisterRepository<ClientBranchRegisterBaseDTO> _clientBranchRego;
        private IBranchRepository<BranchBaseDTO> _branchRepository;
        private IAdvertRepository<AdvertBaseDTO> _advertRepository;
        private IViewingRepository<ViewingBaseDTO> _viewingRepository;
        private ILeaseRepository<LeaseBaseDTO> _leaseRepository;


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

        public IPropertyRepository<AddAPropertyDTO> Property
        {
            get
            {
                if (_property == null)
                {
                    _property = new PropertyRepository<AddAPropertyDTO>(_repoContext);
                }

                return _property;
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

        public IClientBranchRegisterRepository<ClientBranchRegisterBaseDTO> ClientBranchRego
        {
            get
            {
                if (_clientBranchRego == null)
                {
                    _clientBranchRego = new ClientBranchRegisterRepository<ClientBranchRegisterBaseDTO>(_repoContext);
                }

                return _clientBranchRego;
            }
        }

        public IBranchRepository<BranchBaseDTO> BranchRepository
        {
            get
            {
                if (_branchRepository == null)
                {
                    _branchRepository = new BranchRepository<BranchBaseDTO>(_repoContext);
                }

                return _branchRepository;
            }
        }

        public IAdvertRepository<AdvertBaseDTO> AdvertRepository
        {
            get
            {
                if (_advertRepository == null)
                {
                    _advertRepository = new AdvertRepository<AdvertBaseDTO>(_repoContext);
                }

                return _advertRepository;
            }
        }

        public IViewingRepository<ViewingBaseDTO> ViewingRepository
        {
            get
            {
                if (_viewingRepository == null)
                {
                    _viewingRepository = new ViewingRepository<ViewingBaseDTO>(_repoContext);
                }

                return _viewingRepository;
            }
        }
        
        public ILeaseRepository<LeaseBaseDTO> LeaseRepository
        {
            get
            {
                if (_leaseRepository == null)
                {
                    _leaseRepository = new LeaseRepository<LeaseBaseDTO>(_repoContext);
                }

                return _leaseRepository;
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

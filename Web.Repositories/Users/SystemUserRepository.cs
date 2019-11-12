using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects;
using Web.Entities.DataTransferObjects.BranchRegistrationDTOs;
using Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs;
using Web.Entities.Mappers;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class SystemUserRepository : RepositoryBase<TblSystemUser>, ISystemUserRepository
    {
        private readonly Dat502Ass2DBContext _dat502Ass2DBContext;

        public SystemUserRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {
            _dat502Ass2DBContext = dat502Ass2DBContext;
        }

        public IEnumerable<TblSystemUser> GetAllSystemUsers()
        {
            return FindAll()
                .OrderBy(su => su.SystemUserNo)
                .ToList();
        }

        public TblSystemUser GetSystemUser(RegisterBaseUserDTO userRego)
        {
            var user = Dat502Ass2DBContext.TblSystemUser.SingleOrDefault(x => x.UserName == userRego.UserName);
            if (user == null)
            {
                return null;
            }
            return user;
        }


        public TblSystemUser GetSystemUserById(int userId)
        {
            var user = Dat502Ass2DBContext.TblSystemUser.SingleOrDefault(x => x.SystemUserNo == userId);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public LoginResponseDTO Login(LoginDTO login)
        {
            var user = Dat502Ass2DBContext.TblSystemUser.SingleOrDefault(x => x.UserName == login.UserName);
            if (user == null)
            {
                return new LoginResponseDTO {
                    Success = false,
                    Message = "Incorrect username"
                };
            }

            if (user.UserPassword == login.UserPassword)
            {
                return new LoginResponseDTO
                {
                    Success = true,
                    UserId = user.SystemUserNo,
                    UserType = user.SystemUserTypeNo
                };
            }
            
            return new LoginResponseDTO
            {
                Success = false,
                Message = "Incorrect password"
            };
        }

        public int GetUserType(int userId)
        {
            var user = _dat502Ass2DBContext.TblSystemUser.FirstOrDefault(x => x.SystemUserNo == userId);

            return user.SystemUserTypeNo;
        }

        public TblSystemUser GetUserByUserNameAndUserType(string userName)
        {
            var user = _dat502Ass2DBContext.TblSystemUser.FirstOrDefault(x =>
                                                                        x.UserName == userName &&
                                                                        x.SystemUserTypeNo == 4
                                                                        );
            if (user == null)
            {
                return null;
            }
            return user;
        }

    }
}

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
    public class SystemUserRepository : RepositoryBase<TblSystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {
        }

        public IEnumerable<TblSystemUser> GetAllSystemUsers()
        {
            return FindAll()
                .OrderBy(su => su.SystemUserNo)
                .ToList();
        }

        public TblSystemUser GetRegisteredClientSystemUser(RegisterBaseUserDTO userRego)
        {
            var user = Dat502Ass2DBContext.TblSystemUser.SingleOrDefault(x => x.UserName == userRego.UserName);
            if (user == null)
            {
                return null;
            }
            return null;
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
                    Success = true
                };
            }
            
            return new LoginResponseDTO
            {
                Success = false,
                Message = "Incorrect password"
            };


        }

        
        public TblSystemUser Register(RegisterBaseUserDTO userRego)
        {
            var user = Dat502Ass2DBContext.TblSystemUser.Any(x => x.UserName == userRego.UserName);

            return user ? null : RegisterResponseToSystemUserMapper.Map(userRego);
        }
        

        public TblSystemUser RegisterClient(RegisterBaseUserDTO userRego)
        {
            var user = Dat502Ass2DBContext.TblSystemUser.Any(x => x.UserName == userRego.UserName);

            return user ? null : RegisterResponseToSystemUserMapper.Map(userRego);
        }

       
    }
}

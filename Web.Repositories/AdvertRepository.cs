using System.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects.AdvertDTOs;
using Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs;
using Web.Entities.Mappers;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class AdvertRepository<T> : RepositoryBase<T>, IAdvertRepository<T> where T: AdvertBaseDTO
    {
        private readonly Dat502Ass2DBContext _context;
        
        public AdvertRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {
            _context = dat502Ass2DBContext;
        }

        public TblAdvert AddAdvert<U>(U entity) where U : CreateAdvertDTO
        {
            // check property exists
            var property = _context.TblProperty.Any(x => x.PropertyNo == entity.PropertyNo);
            if (property)
            {
                var newAdvert = entity.Map();

                return newAdvert;
            }
            return null;
        }

        public void CreateAdvert<U>(U entity) where U : TblAdvert
        {
            Dat502Ass2DBContext.TblAdvert.Add(entity);
        }


    }
}
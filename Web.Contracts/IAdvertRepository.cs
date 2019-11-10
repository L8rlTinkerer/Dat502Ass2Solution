using Web.Entities.DataTransferObjects.AdvertDTOs;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface IAdvertRepository<T> : IRepositoryBase<T>
    {

        TblAdvert AddAdvert<U>(U entity) where U : CreateAdvertDTO;
        void CreateAdvert<U>(U entity) where U : TblAdvert;

    }
}
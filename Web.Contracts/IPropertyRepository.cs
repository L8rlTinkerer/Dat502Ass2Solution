using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects.PropertyDTOs;
using Web.Entities.Models;

namespace Web.Contracts
{
    public interface IPropertyRepository<T> : IRepositoryBase<T>
    {
        IEnumerable<TblProperty> GetAllProperties();

        TblProperty AddProperty(T entity);
        void CreateProperty<U>(U entity) where U : TblProperty;



    }
}

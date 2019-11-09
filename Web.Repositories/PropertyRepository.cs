using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Web.Contracts;
using Web.Entities.DataTransferObjects;
using Web.Entities.DataTransferObjects.PropertyDTOs;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class PropertyRepository<T> : RepositoryBase<T>, IPropertyRepository<T> where T: AddAPropertyDTO
    {
        public PropertyRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {

        }

        public IEnumerable<TblProperty> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public TblProperty GetProperty(AddAPropertyDTO property)
        {
            throw new NotImplementedException();
        }

        public TblProperty GetProperty(T entity)
        {
            throw new NotImplementedException();
        }

        public TblProperty AddProperty(T entity)
        {
            var property = Dat502Ass2DBContext.TblProperty.Any(x => 
                                        x.AddressNoNavigation.StreetNumber == entity.AddressNoNavigation.StreetNumber &&
                                        x.AddressNoNavigation.StreetOrRoadName == entity.AddressNoNavigation.StreetOrRoadName &&
                                        x.AddressNoNavigation.CityOrTownName == entity.AddressNoNavigation.CityOrTownName &&
                                        x.AddressNoNavigation.PostCode == entity.AddressNoNavigation.PostCode
                                        );
            
            return property ? null: entity.Map();
        }


        public void CreateProperty<U>(U entity) where U : TblProperty
        {
            Dat502Ass2DBContext.TblProperty.Add(entity);
        }
    }
}
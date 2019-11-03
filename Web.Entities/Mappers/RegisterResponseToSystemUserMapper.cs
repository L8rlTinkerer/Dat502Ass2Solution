using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Entities.Mappers
{
    public static class RegisterResponseToSystemUserMapper
    {
        public static TblSystemUser Map(RegisterDTO dto)
        {
            var address = new TblAddress
            {
                StreetNumber = dto.AddressNoNavigation.StreetNumber,
                StreetOrRoadName = dto.AddressNoNavigation.StreetOrRoadName,
                CityOrTownName = dto.AddressNoNavigation.CityOrTownName,
                PostCode = dto.AddressNoNavigation.PostCode
            };

            return new TblSystemUser
            {
               
                AddressNoNavigation = address,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                UserPassword = dto.UserPassword,
                PhoneNumber = dto.PhoneNumber,
                SystemUserTypeNo = 4, // At the point of coding, only one user type (client) was registering via this method. 

                AddressNo = address.AddressNo
            };
        }
    }
}

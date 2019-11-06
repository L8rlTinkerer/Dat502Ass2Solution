using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Entities.Mappers
{
    public static class RegisterResponseToSystemUserMapper
    {
        public static TblSystemUser Map(RegisterSystemUserDTO dto)
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
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                UserPassword = dto.UserPassword,
                PhoneNumber = dto.PhoneNumber,
                AddressNoNavigation = address,
                AddressNo = address.AddressNo,
                SystemUserTypeNo = Convert.ToByte(4)//Convert.ToByte(dto.SystemUserTypeNo)  
            };
            
        }
    }
}

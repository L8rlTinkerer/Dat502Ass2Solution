using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects
{
    public class RegisterOwnerDTO : RegisterBaseUserDTO
    {
        [Required(ErrorMessage = "Please select a owner type.")]
        public byte OwnerTypeNo { get; set; }

        [Required(ErrorMessage = "Please select if you are active.")]
        public bool IsOwnerActive { get; set; }

        public override TblSystemUser Map()
        {
            var address = new TblAddress
            {
                StreetNumber = AddressNoNavigation.StreetNumber,
                StreetOrRoadName = AddressNoNavigation.StreetOrRoadName,
                CityOrTownName = AddressNoNavigation.CityOrTownName,
                PostCode = AddressNoNavigation.PostCode
            };

            var owner = new Collection<TblOwner>
            {
                new TblOwner
                {
                    OwnerTypeNo = Convert.ToByte(this.OwnerTypeNo),
                    IsOwnerActive = this.IsOwnerActive
                }
            };

            return new TblSystemUser
            {

                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                UserPassword = UserPassword,
                PhoneNumber = PhoneNumber,
                AddressNoNavigation = address,
                AddressNo = address.AddressNo,
                SystemUserTypeNo = Convert.ToByte(SystemUserTypeNo),
                TblOwner = owner
            };
        }


    }
}

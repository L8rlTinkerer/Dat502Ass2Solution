using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects
{
    public class RegisterClientDTO : RegisterBaseUserDTO
    {
        [Required(ErrorMessage = "Please add notes about your Preferred Accomodation Type")]
        [MaxLength(100, ErrorMessage = "PreferredAccomodationType notes can be no more than 100 characters.")]
        public string PreferredAccomodationType { get; set; }

        [Required(ErrorMessage = "Please add your Maximum Rent")]
        public int MaximumRent { get; set; }

        [Required(ErrorMessage = "Please indicate if you are looking for a property.")]
        public bool IsActive { get; set; }

        public override TblSystemUser Map()
        {
            var address = new TblAddress
            {
                StreetNumber = AddressNoNavigation.StreetNumber,
                StreetOrRoadName = AddressNoNavigation.StreetOrRoadName,
                CityOrTownName = AddressNoNavigation.CityOrTownName,
                PostCode = AddressNoNavigation.PostCode
            };

            var client = new Collection<TblClient>
            {
                new TblClient
                {
                    PreferredAccomodationType = this.PreferredAccomodationType,
                    MaximumRent = this.MaximumRent,
                    IsActive = this.IsActive
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
                TblClient = client
            };
        }

    }
}

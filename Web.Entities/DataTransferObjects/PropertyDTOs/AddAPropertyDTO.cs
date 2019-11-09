using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects.PropertyDTOs
{
    public class AddAPropertyDTO
    {
        [Required(ErrorMessage = "An OwnerNo is required.")]
        public int OwnerNo { get; set; }

        [Required(ErrorMessage = "Please select a owner type.")]
        public byte BranchNo { get; set; }

        [Required(ErrorMessage = "A StaffNo is required.")]
        public int StaffNo { get; set; }

        [Required(ErrorMessage = "Please select a Property Type.")]
        public byte PropertyTypeNo { get; set; }

        [Required(ErrorMessage = "Please select the number of bedrooms in the property.")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Please indicate the Monthly Rent.")]
        public int MonthlyRent { get; set; }

        [Required(ErrorMessage = "Please select if the property is active.")]
        public bool IsPropertyActive { get; set; }

        public AddressDTO AddressNoNavigation { get; set; }

        public TblProperty Map()
        {
            var address = new TblAddress
            {
                StreetNumber = AddressNoNavigation.StreetNumber,
                StreetOrRoadName = AddressNoNavigation.StreetOrRoadName,
                CityOrTownName = AddressNoNavigation.CityOrTownName,
                PostCode = AddressNoNavigation.PostCode
            };


            return new TblProperty
            {
                OwnerNo = this.OwnerNo,
                BranchNo = this.BranchNo,
                AddressNoNavigation = address,
                AddressNo = address.AddressNo,
                PropertyTypeNo = Convert.ToByte(this.PropertyTypeNo),
                StaffNo = this.StaffNo,
                NumberOfRooms = this.NumberOfRooms,
                MonthlyRent = this.MonthlyRent,
                IsPropertyActive= this.IsPropertyActive

            };
        }

    }
}
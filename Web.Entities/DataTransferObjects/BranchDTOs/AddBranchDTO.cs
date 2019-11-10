using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects.BranchDTOs
{
    public class AddBranchDTO : BranchBaseDTO
    {
        [Required(ErrorMessage = "A StaffNo is required.")]
        public int StaffNo { get; set; }

        public AddressDTO AddressNoNavigation { get; set; }

        //[MinLength(10, ErrorMessage = "Minimum length it 10 characters.")]
        //[RegularExpression(@"^([0-9]{2}[-][0-9]{7})$", ErrorMessage = "Please enter valid phone no.")]
        //[DataType(DataType.PhoneNumber)]
        //[MaxLength(10, ErrorMessage = "Maximum length it 10 characters.")]
        [Required(ErrorMessage = "A Phone number is required.")]
        public string Phone { get; set; }

        public TblBranch Map()
        {
            var address = new TblAddress
            {
                StreetNumber = AddressNoNavigation.StreetNumber,
                StreetOrRoadName = AddressNoNavigation.StreetOrRoadName,
                CityOrTownName = AddressNoNavigation.CityOrTownName,
                PostCode = AddressNoNavigation.PostCode
            };

            return new TblBranch
            {
                AddressNoNavigation = address,
                AddressNo = address.AddressNo,
                Phone = Phone
            };
        }

    }

}


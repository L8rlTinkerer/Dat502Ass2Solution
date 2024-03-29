﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects
{
    public class RegisterBaseUserDTO
    {
        [MaxLength(50, ErrorMessage = "FirstName can be no more than 50 characters.")]
        [Required(ErrorMessage = "Please add a First Name")]
        public string FirstName { get; set; }

        [MaxLength(75, ErrorMessage = "LastName can be no more than 75 characters.")]
        [Required(ErrorMessage = "Please add a Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "UserName can be no more than 50 characters.")]
        [Required(ErrorMessage = "Please add a UserName")]
        public string UserName { get; set; }

        [MaxLength(15, ErrorMessage = "UserPassword can be no more than 15 characters.")]
        [Required(ErrorMessage = "Please add a User assword")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "A Phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10, ErrorMessage = "Maximum length it 10 characters.")]
        //[MinLength(10, ErrorMessage = "Minimum length it 10 characters.")]
        //[RegularExpression(@"^([0-9]{2}[-][0-9]{7})$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        
        public AddressDTO AddressNoNavigation { get; set; }

        [Required(ErrorMessage = "A SystemUserType needs to be specified.")]
        public int SystemUserTypeNo { get; set; }


        public virtual TblSystemUser Map()
        {
            var address = new TblAddress
            {
                StreetNumber = AddressNoNavigation.StreetNumber,
                StreetOrRoadName = AddressNoNavigation.StreetOrRoadName,
                CityOrTownName = AddressNoNavigation.CityOrTownName,
                PostCode = AddressNoNavigation.PostCode
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
                SystemUserTypeNo = Convert.ToByte(SystemUserTypeNo)  
            };
        }



    }
}

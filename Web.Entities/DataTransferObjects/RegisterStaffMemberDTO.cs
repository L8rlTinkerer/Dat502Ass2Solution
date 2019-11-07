using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects
{
    public class RegisterStaffMemberDTO : RegisterBaseUserDTO
    {
        [Required(ErrorMessage = "Please select a branch.")]
        public int BranchNo { get; set; }

        [Required(ErrorMessage = "Please select the gender that the staff member identifies with best.")]
        public byte GenderNo { get; set; }

        [Required(ErrorMessage = "Please enter a salary")]
        public int Salary { get; set; }


        public override TblSystemUser Map()
        {
            var address = new TblAddress
            {
                StreetNumber = AddressNoNavigation.StreetNumber,
                StreetOrRoadName = AddressNoNavigation.StreetOrRoadName,
                CityOrTownName = AddressNoNavigation.CityOrTownName,
                PostCode = AddressNoNavigation.PostCode
            };

            var assistant = new Collection<TblStaff>
            {
                new TblStaff
                {
                    BranchNo = Convert.ToByte(this.BranchNo),
                    GenderNo = Convert.ToByte(this.GenderNo),
                    Salary = this.Salary
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
                TblStaff = assistant
            };
        }
    }
}

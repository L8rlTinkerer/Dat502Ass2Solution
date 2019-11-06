using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Entities.DataTransferObjects
{
    public class RegisterSystemUserDTO
    {
        [MaxLength(50, ErrorMessage = "FirstName can be no more than 50 characters.")]
        [Required(ErrorMessage = "Please add a First Name")]
        public string FirstName { get; set; }

        [MaxLength(75, ErrorMessage = "LastName can be no more than 75 characters.")]
        [Required(ErrorMessage = "Please add a Last Name")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "UserName can be no more than 50 characters.")]
        [Required(ErrorMessage = "Please add a UserName")]
        public string UserName { get; set; }

        [MaxLength(15, ErrorMessage = "UserPassword can be no more than 15 characters.")]
        [Required(ErrorMessage = "Please add a User assword")]
        public string UserPassword { get; set; }

        [MaxLength(10, ErrorMessage = "?")]
        [Required(ErrorMessage = "?")]
        public string PhoneNumber { get; set; }

        public AddressDTO AddressNoNavigation { get; set; }

        public int SystemUserTypeNo { get; set; }

        
        public string PreferredAccomodationType { get; set; }
        public int MaximumRent { get; set; }
        public bool IsActive { get; set; }
    }
}

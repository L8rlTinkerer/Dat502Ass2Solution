using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Entities.DataTransferObjects
{
    public class RegisterDTO
    {
        [ForeignKey("AddressNo")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string PhoneNumber { get; set; }

        public AddressDTO AddressNoNavigation { get; set; }
    }
}

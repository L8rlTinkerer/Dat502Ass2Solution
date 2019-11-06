using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entities.DataTransferObjects
{
    public class RegisterClientDTO
    {
        public int SystemUserNo { get; set; }

        [MaxLength(100, ErrorMessage = "PreferredAccomodationType notes can be no more than 100 characters.")]
        public string PreferredAccomodationType { get; set; }

        [Required(ErrorMessage = "Please add your Maximum Rent")]
        public int MaximumRent { get; set; }

        [Required(ErrorMessage = "Please indicate if you are looking for a property.")]
        public bool IsActive { get; set; }
    }
}

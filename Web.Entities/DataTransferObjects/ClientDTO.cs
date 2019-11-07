using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entities.DataTransferObjects
{
    public class ClientDTO
    {
        [Required(ErrorMessage = "SystemUserNo is required but ot set.")]
        public int SystemUserNo { get; set; }

        [Required(ErrorMessage = "Please enter a few notes here.")]
        public string PreferredAccomodationType { get; set; }

        [Required(ErrorMessage = "Please add enter the maximum rent you wish to pay.")]
        public int MaximumRent { get; set; }


        public bool IsActive { get; set; }
    }
}

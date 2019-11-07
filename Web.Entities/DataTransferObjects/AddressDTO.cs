using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entities.DataTransferObjects
{
    public class AddressDTO
    {
        [DataType(DataType.Text)]
        [MaxLength(4,ErrorMessage = "Street number max length of 4.")]
        [Required(ErrorMessage = "Please add a Street number")]
        public string StreetNumber { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "Street name can be no more than 100 characters.")]
        [Required(ErrorMessage = "Please add a Street name")]
        public string StreetOrRoadName { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "City/town name can be no more than 100 characters.")]
        [Required(ErrorMessage = "Please add a City/town name")]
        public string CityOrTownName { get; set; }

        [DataType(DataType.PostalCode)]
        [MaxLength(4, ErrorMessage = "Postcode max length of 4.")]
        [Required(ErrorMessage = "Please add a Postcode")]
        public string PostCode { get; set; }
    }
}

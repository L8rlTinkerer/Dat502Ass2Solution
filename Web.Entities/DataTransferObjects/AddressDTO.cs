using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entities.DataTransferObjects
{
    public class AddressDTO
    {
        public string StreetNumber { get; set; }
        public string StreetOrRoadName { get; set; }
        public string CityOrTownName { get; set; }
        public string PostCode { get; set; }
    }
}

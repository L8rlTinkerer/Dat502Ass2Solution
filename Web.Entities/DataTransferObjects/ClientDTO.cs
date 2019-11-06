using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entities.DataTransferObjects
{
    public class ClientDTO
    {
        public int SystemUserNo { get; set; }
        public string PreferredAccomodationType { get; set; }
        public int MaximumRent { get; set; }
        public bool IsActive { get; set; }
    }
}

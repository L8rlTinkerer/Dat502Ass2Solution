using System;
using System.Collections.Generic;

namespace Web.API.Models
{
    public partial class TblAddress
    {
        public TblAddress()
        {
            TblBranch = new HashSet<TblBranch>();
            TblProperty = new HashSet<TblProperty>();
            TblSystemUser = new HashSet<TblSystemUser>();
        }

        public int AddressNo { get; set; }
        public string StreetNumber { get; set; }
        public string StreetOrRoadName { get; set; }
        public string CityOrTownName { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<TblBranch> TblBranch { get; set; }
        public virtual ICollection<TblProperty> TblProperty { get; set; }
        public virtual ICollection<TblSystemUser> TblSystemUser { get; set; }
    }
}

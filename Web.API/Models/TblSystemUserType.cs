using System;
using System.Collections.Generic;

namespace Web.API.Models
{
    public partial class TblSystemUserType
    {
        public TblSystemUserType()
        {
            TblSystemUser = new HashSet<TblSystemUser>();
        }

        public byte SystemUserTypeNo { get; set; }
        public string SystemUserType { get; set; }
        public string SystemUserTypeDesc { get; set; }

        public virtual ICollection<TblSystemUser> TblSystemUser { get; set; }
    }
}

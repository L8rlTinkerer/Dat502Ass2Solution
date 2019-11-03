using System;
using System.Collections.Generic;

namespace Web.API.Models
{
    public partial class TblLeaseType
    {
        public TblLeaseType()
        {
            TblLease = new HashSet<TblLease>();
        }

        public byte LeaseTypeNo { get; set; }
        public short LeaseType { get; set; }
        public string LeaseTypeDesc { get; set; }

        public virtual ICollection<TblLease> TblLease { get; set; }
    }
}

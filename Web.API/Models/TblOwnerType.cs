using System;
using System.Collections.Generic;

namespace Web.API.Models
{
    public partial class TblOwnerType
    {
        public TblOwnerType()
        {
            TblOwner = new HashSet<TblOwner>();
        }

        public byte OwnerTypeNo { get; set; }
        public string OwnerType { get; set; }
        public string OwnerTypeDesc { get; set; }

        public virtual ICollection<TblOwner> TblOwner { get; set; }
    }
}

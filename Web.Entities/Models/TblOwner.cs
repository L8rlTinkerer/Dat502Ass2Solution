using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblOwner
    {
        public TblOwner()
        {
            TblProperty = new HashSet<TblProperty>();
        }

        public int OwnerNo { get; set; }
        public byte OwnerTypeNo { get; set; }
        public int SystemUserNo { get; set; }
        public bool IsOwnerActive { get; set; }

        public virtual TblOwnerType OwnerTypeNoNavigation { get; set; }
        public virtual TblSystemUser SystemUserNoNavigation { get; set; }
        public virtual ICollection<TblProperty> TblProperty { get; set; }
    }
}

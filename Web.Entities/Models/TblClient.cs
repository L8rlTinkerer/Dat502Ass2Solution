using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblClient
    {
        public TblClient()
        {
            TblLease = new HashSet<TblLease>();
            TblRegistration = new HashSet<TblRegistration>();
            TblViewing = new HashSet<TblViewing>();
        }

        public int ClientNo { get; set; }
        public int SystemUserNo { get; set; }
        public string PreferredAccomodationType { get; set; }
        public int MaximumRent { get; set; }
        public bool IsActive { get; set; }

        public virtual TblSystemUser SystemUserNoNavigation { get; set; }
        public virtual ICollection<TblLease> TblLease { get; set; }
        public virtual ICollection<TblRegistration> TblRegistration { get; set; }
        public virtual ICollection<TblViewing> TblViewing { get; set; }
    }
}

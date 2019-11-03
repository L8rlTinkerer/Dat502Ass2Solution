using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblBranch
    {
        public TblBranch()
        {
            TblProperty = new HashSet<TblProperty>();
            TblRegistration = new HashSet<TblRegistration>();
            TblStaff = new HashSet<TblStaff>();
        }

        public int BranchNo { get; set; }
        public int AddressNo { get; set; }
        public string Phone { get; set; }

        public virtual TblAddress AddressNoNavigation { get; set; }
        public virtual ICollection<TblProperty> TblProperty { get; set; }
        public virtual ICollection<TblRegistration> TblRegistration { get; set; }
        public virtual ICollection<TblStaff> TblStaff { get; set; }
    }
}

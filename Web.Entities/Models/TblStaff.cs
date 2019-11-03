using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblStaff
    {
        public TblStaff()
        {
            TblProperty = new HashSet<TblProperty>();
            TblRegistration = new HashSet<TblRegistration>();
        }

        public int StaffNo { get; set; }
        public int BranchNo { get; set; }
        public int SystemUserNo { get; set; }
        public byte GenderNo { get; set; }
        public int Salary { get; set; }

        public virtual TblBranch BranchNoNavigation { get; set; }
        public virtual TblGender GenderNoNavigation { get; set; }
        public virtual TblSystemUser SystemUserNoNavigation { get; set; }
        public virtual ICollection<TblProperty> TblProperty { get; set; }
        public virtual ICollection<TblRegistration> TblRegistration { get; set; }
    }
}

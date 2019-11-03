using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblProperty
    {
        public TblProperty()
        {
            TblAdvert = new HashSet<TblAdvert>();
            TblLease = new HashSet<TblLease>();
            TblViewing = new HashSet<TblViewing>();
        }

        public int PropertyNo { get; set; }
        public int OwnerNo { get; set; }
        public int BranchNo { get; set; }
        public int AddressNo { get; set; }
        public byte PropertyTypeNo { get; set; }
        public int StaffNo { get; set; }
        public int NumberOfRooms { get; set; }
        public int MonthlyRent { get; set; }
        public bool IsPropertyActive { get; set; }

        public virtual TblAddress AddressNoNavigation { get; set; }
        public virtual TblBranch BranchNoNavigation { get; set; }
        public virtual TblOwner OwnerNoNavigation { get; set; }
        public virtual TblPropertyType PropertyTypeNoNavigation { get; set; }
        public virtual TblStaff StaffNoNavigation { get; set; }
        public virtual ICollection<TblAdvert> TblAdvert { get; set; }
        public virtual ICollection<TblLease> TblLease { get; set; }
        public virtual ICollection<TblViewing> TblViewing { get; set; }
    }
}

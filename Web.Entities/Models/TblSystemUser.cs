using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblSystemUser
    {
        public TblSystemUser()
        {
            TblClient = new HashSet<TblClient>();
            TblOwner = new HashSet<TblOwner>();
            TblStaff = new HashSet<TblStaff>();
        }

        public int SystemUserNo { get; set; }
        public byte SystemUserTypeNo { get; set; }
        public int AddressNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string PhoneNumber { get; set; }

        public virtual TblAddress AddressNoNavigation { get; set; }
        public virtual TblSystemUserType SystemUserTypeNoNavigation { get; set; }
        public virtual ICollection<TblClient> TblClient { get; set; }
        public virtual ICollection<TblOwner> TblOwner { get; set; }
        public virtual ICollection<TblStaff> TblStaff { get; set; }
    }
}

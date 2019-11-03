using System;
using System.Collections.Generic;

namespace Web.API.Models
{
    public partial class TblRegistration
    {
        public int RegistrationNo { get; set; }
        public int StaffNo { get; set; }
        public int BranchNo { get; set; }
        public int ClientNo { get; set; }
        public DateTime DateJoined { get; set; }

        public virtual TblBranch BranchNoNavigation { get; set; }
        public virtual TblClient ClientNoNavigation { get; set; }
        public virtual TblStaff StaffNoNavigation { get; set; }
    }
}

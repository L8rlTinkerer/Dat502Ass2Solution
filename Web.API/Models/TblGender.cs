using System;
using System.Collections.Generic;

namespace Web.API.Models
{
    public partial class TblGender
    {
        public TblGender()
        {
            TblStaff = new HashSet<TblStaff>();
        }

        public byte GenderNo { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<TblStaff> TblStaff { get; set; }
    }
}

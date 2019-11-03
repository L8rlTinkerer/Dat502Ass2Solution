using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblViewing
    {
        public int ViewingNo { get; set; }
        public int PropertyNo { get; set; }
        public int ClientNo { get; set; }
        public DateTime DateViewed { get; set; }
        public string ClientComment { get; set; }

        public virtual TblClient ClientNoNavigation { get; set; }
        public virtual TblProperty PropertyNoNavigation { get; set; }
    }
}

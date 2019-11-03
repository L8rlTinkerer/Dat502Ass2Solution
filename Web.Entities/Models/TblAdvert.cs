using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblAdvert
    {
        public int AdvertNo { get; set; }
        public int PropertyNo { get; set; }
        public DateTime DateAdvertised { get; set; }
        public string NewsPaperName { get; set; }

        public virtual TblProperty PropertyNoNavigation { get; set; }
    }
}

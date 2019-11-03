using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblPropertyType
    {
        public TblPropertyType()
        {
            TblProperty = new HashSet<TblProperty>();
        }

        public byte PropertyTypeNo { get; set; }
        public string PropertyType { get; set; }
        public string PropertyTypeDesc { get; set; }

        public virtual ICollection<TblProperty> TblProperty { get; set; }
    }
}

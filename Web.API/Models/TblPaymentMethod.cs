using System;
using System.Collections.Generic;

namespace Web.API.Models
{
    public partial class TblPaymentMethod
    {
        public TblPaymentMethod()
        {
            TblLease = new HashSet<TblLease>();
        }

        public byte PaymentMethodNo { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentMethodDesc { get; set; }

        public virtual ICollection<TblLease> TblLease { get; set; }
    }
}

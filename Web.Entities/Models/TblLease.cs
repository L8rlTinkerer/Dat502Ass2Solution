using System;
using System.Collections.Generic;

namespace Web.Entities.Models
{
    public partial class TblLease
    {
        public int LeaseNo { get; set; }
        public int PropertyNo { get; set; }
        public int ClientNo { get; set; }
        public byte LeaseTypeNo { get; set; }
        public byte PaymentMethodNo { get; set; }
        public int DepositAmount { get; set; }
        public bool DepositPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual TblClient ClientNoNavigation { get; set; }
        public virtual TblLeaseType LeaseTypeNoNavigation { get; set; }
        public virtual TblPaymentMethod PaymentMethodNoNavigation { get; set; }
        public virtual TblProperty PropertyNoNavigation { get; set; }
    }
}

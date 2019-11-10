using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects.LeaseDTOs
{
    public class CreateLeaseDTO
    {
        public int PropertyNo { get; set; }
        public int ClientNo { get; set; }
        public byte LeaseTypeNo { get; set; }
        public byte PaymentMethodNo { get; set; }
        public int DepositAmount { get; set; }
        public bool DepositPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TblLease Map()
        {
            return new TblLease()
            {
                PropertyNo = PropertyNo,
                ClientNo = ClientNo,
                LeaseTypeNo = Convert.ToByte(LeaseTypeNo),
                PaymentMethodNo = Convert.ToByte(PaymentMethodNo),
                DepositAmount = DepositAmount,
                DepositPaid = Convert.ToBoolean(DepositPaid),
                StartDate = Convert.ToDateTime(StartDate),
                EndDate = Convert.ToDateTime(EndDate)
            };
        }

    }
}

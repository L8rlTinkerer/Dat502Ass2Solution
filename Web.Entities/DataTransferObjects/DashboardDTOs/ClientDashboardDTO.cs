using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entities.DataTransferObjects.DashboardDTOs
{
    public class ClientDashboardDTO
    {
        public int BranchNo { get; set; }
        public int PropertyNo { get; set; }
        public int MonthlyRent { get; set; }
        public int NumberOfRooms { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}


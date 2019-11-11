using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects.DashboardDTOs;
using Web.Entities.Models;

namespace Web.Repositories.Users
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly Dat502Ass2DBContext _context;

        public DashboardRepository(Dat502Ass2DBContext context)
        {
            _context = context;
        }

        public List<ClientDashboardDTO> GetClientDashboard(int userId)
        {
            TblClient client = _context.TblClient.FirstOrDefault(x => x.SystemUserNo == userId);

            if (client == null)
            {
                return null;
            }

            var param = new SqlParameter("@ClientNo", client.ClientNo);
            var dashboard = _context.ClientDashboard.FromSql($"" +
                                                             $"SELECT re.BranchNo, pr.PropertyNo, pr.MonthlyRent, pr.NumberOfRooms, su.FirstName, su.LastName, su.PhoneNumber " +
                                                             $"FROM tbl_Registration re " +
                                                             $"INNER JOIN tbl_Property pr " +
                                                             $"ON re.BranchNo = re.BranchNo " +
                                                             $"INNER JOIN tbl_Staff st " +
                                                             $"ON pr.StaffNo = st.StaffNo " +
                                                             $"INNER JOIN tbl_SystemUser su " +
                                                             $"ON st.SystemUserNo = su.SystemUserNo " +
                                                             $"WHERE re.BranchNo = @ClientNo", param).ToList();

            return dashboard;
        }


    }
}

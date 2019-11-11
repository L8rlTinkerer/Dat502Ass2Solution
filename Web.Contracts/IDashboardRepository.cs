using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects.DashboardDTOs;

namespace Web.Contracts
{
    public interface IDashboardRepository
    {
        List<ClientDashboardDTO> GetClientDashboard(int userType);
    }
}

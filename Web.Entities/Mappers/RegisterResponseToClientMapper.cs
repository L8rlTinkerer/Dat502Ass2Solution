using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Entities.Mappers
{
    public static class RegisterResponseToClientMapper
    {
        public static TblClient Map(RegisterClientDTO dto)
        {
            return new TblClient
            {
                SystemUserNo = dto.SystemUserNo,
                PreferredAccomodationType = dto.PreferredAccomodationType,
                MaximumRent = dto.MaximumRent,
                IsActive = dto.IsActive
            };
        }
    }
}

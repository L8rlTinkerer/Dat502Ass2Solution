﻿using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.DataTransferObjects;
using Web.Entities.Models;

namespace Web.Entities.Mappers
{
    public static class RegisterSystemUserDTOtoRegisterClientDTOMapper
    {
        public static RegisterClientDTO Map(RegisterBaseUserDTO dto, TblSystemUser su)
        {
            return new RegisterClientDTO
            {
                //SystemUserNo = su.SystemUserNo,
                //PreferredAccomodationType = dto.PreferredAccomodationType,
                //MaximumRent = dto.MaximumRent,
                //IsActive = dto.IsActive
            };
        }
    }
}

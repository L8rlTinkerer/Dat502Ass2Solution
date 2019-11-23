using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs
{
    public class InitalRequestToAddCBRDTO : ClientBranchRegisterBaseDTO
    {

        [Required(ErrorMessage = "An StaffSystemUserNo is required.")]
        public int SystemUserNo { get; set; }

        [Required(ErrorMessage = "An ClientSystemUserNo is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "An BranchNo is required.")]
        public int BranchNo { get; set; }

       

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects.ClientBranchRegistrationDTOs
{
    public class AddClientBranchRegisterDTO : ClientBranchRegisterBaseDTO
    {
        [Required(ErrorMessage = "An StaffNo is required.")]
        public int StaffNo { get; set; }

        [Required(ErrorMessage = "An BranchNo is required.")]
        public int BranchNo { get; set; }

        [Required(ErrorMessage = "An ClientNo is required.")]
        public int ClientNo { get; set; }

        public TblRegistration Map()
        {
            return new TblRegistration
            {
                StaffNo = this.StaffNo,
                BranchNo = this.BranchNo,
                ClientNo = this.ClientNo,
                DateJoined = DateTime.Now
            };
        }

    }
}

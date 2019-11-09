using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entities.DataTransferObjects.BranchDTOs
{
    public class AddBranchResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string JWT { get; set; }
    }
}

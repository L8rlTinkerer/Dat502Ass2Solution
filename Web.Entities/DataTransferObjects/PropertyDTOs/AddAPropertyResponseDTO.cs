using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entities.DataTransferObjects.PropertyDTOs
{
    public class AddAPropertyResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string JWT { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entities.DataTransferObjects
{
    public class LoginResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string JWT { get; set; }
    }
}

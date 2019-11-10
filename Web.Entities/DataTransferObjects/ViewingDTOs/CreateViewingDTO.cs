using System;
using System.Collections.Generic;
using System.Text;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects.ViewingDTOs
{
    public class CreateViewingDTO : ViewingBaseDTO
    {
        public int PropertyNo { get; set; }

        public int ClientNo { get; set; }

        public DateTime DateViewed { get; set; }

        public string ClientComment { get; set; }

        public TblViewing Map()
        {
            return new TblViewing()
            {
                PropertyNo = PropertyNo,
                ClientNo = ClientNo,
                DateViewed = DateViewed,
                ClientComment = ClientComment
            };
        }
    }
}

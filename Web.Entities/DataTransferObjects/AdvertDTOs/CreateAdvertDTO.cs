using System;
using Web.Entities.Models;

namespace Web.Entities.DataTransferObjects.AdvertDTOs
{
    public class CreateAdvertDTO : AdvertBaseDTO
    {
        public int PropertyNo { get; set; }
        public string NewsPaperName { get; set; }


        public TblAdvert Map()
        {
            return new TblAdvert()
            {
                PropertyNo = PropertyNo,
                DateAdvertised = DateTime.UtcNow,
                NewsPaperName = NewsPaperName
            };
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Contracts;
using Web.Entities.DataTransferObjects.ViewingDTOs;
using Web.Entities.Models;

namespace Web.Repositories
{
    public class ViewingRepository<T> : RepositoryBase<T>, IViewingRepository<T> where T : ViewingBaseDTO
    {
        private readonly Dat502Ass2DBContext _context;

        public ViewingRepository(Dat502Ass2DBContext dat502Ass2DBContext) : base(dat502Ass2DBContext)
        {
            _context = dat502Ass2DBContext;
        }

        public TblViewing AddViewing<U>(U entity) where U : CreateViewingDTO
        {
            // check if viewing exists
            var viewing = _context.TblViewing.Any(x => 
                                        x.PropertyNo == entity.PropertyNo &&
                                        x.ClientNo == entity.ClientNo &&
                                        x.DateViewed == entity.DateViewed
                                        );


            if (viewing)
            {
                return null;
            }

            var newViewing = entity.Map();

            return newViewing;

        }

        public void CreateViewing<U>(U entity) where U : TblViewing
        {
            Dat502Ass2DBContext.TblViewing.Add(entity);
        }
    }
}

using System;
using System.Linq;
using ChickenScratch.Data.Repositories;
using ChickenScratch.Util.Services;

namespace ChickenScratch.Data.Customer
{
    public class ShopperRepository : GenericRepository<ChickenScratchContext, Model.Shopper>, IShopperRepository
    {
        private Response<Model.Shopper> response = null;

        public ShopperRepository(ChickenScratchContext context)
            : base(context)
        {
            response = new Response<Model.Shopper>();
        }

        public Response<Model.Shopper> Insert(Model.Shopper entity)
        {
            try
            {
                base.Add(entity);
                response.Result = entity;
            }
            catch (Exception ex)
            {
                response.SetError(ex, ErrorCode.Database);
            }

            return response;
        }
    }
}

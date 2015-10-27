using ChickenScratch.Data.Repositories;
using ChickenScratch.Util.Services;

namespace ChickenScratch.Data.Customer
{
    public interface IShopperRepository : IGenericRepository<Model.Shopper>
    {
        Response<Model.Shopper> Insert(Model.Shopper entity);
    }
}

using ChickenScratch.Util.Services;

namespace ChickenScratch.Business
{
    public interface IShopperBusiness<T>
    {
        Response<T> Create(T entity);
    }
}

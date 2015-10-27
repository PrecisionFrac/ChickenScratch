using ChickenScratch.Util.Services;

namespace ChickenScratch.Business
{
    public interface IAddressBusiness
    {
        Response<Model.Address> Create(Model.Address address);
    }
}

using ChickenScratch.Util.Services;

namespace ChickenScratch.Business
{
    public interface ICustomerBusiness
    {
        Response<Model.Customer> Create(Model.Customer customer);
    }
}

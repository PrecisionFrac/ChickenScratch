using ChickenScratch.Data.Repositories;
using ChickenScratch.Util.Services;

namespace ChickenScratch.Data.Customer
{
    public interface ICustomerRepository : IGenericRepository<Model.Customer>
    {
        Response<Model.Customer> Insert(Model.Customer customer);

        Model.Customer Update(Model.Customer customer);

        Model.Customer GetBy(Model.Customer customer);

        void Delete(Model.Customer customer);
    }
}

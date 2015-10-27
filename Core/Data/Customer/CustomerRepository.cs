using System;
using System.Linq;
using ChickenScratch.Data.Repositories;
using ChickenScratch.Util.Services;

namespace ChickenScratch.Data.Customer
{
    public class CustomerRepository : GenericRepository<ChickenScratchContext, Model.Customer>, ICustomerRepository
    {
        private Response<Model.Customer> response = null;

        public CustomerRepository(ChickenScratchContext context)
            : base(context)
        {
            response = new Response<Model.Customer>();
        }

        public Response<Model.Customer> Add(Model.Customer customer)
        {
            try
            {
                base.Add(customer);
                response.Result = customer;
            }
            catch (Exception ex)
            {
                response.SetError(ex, ErrorCode.Database);
            }

            return response;
        }

        public Model.Customer Update(Model.Customer customer)
        {
            base.Update(customer);
            return customer;
        }

        public Model.Customer GetBy(Model.Customer customer)
        {
            customer = base.FindBy(c => c.CustomerId == customer.CustomerId).SingleOrDefault();
            return customer;
        }

        public void Delete(Model.Customer customer)
        {
            base.Delete(customer);
        }
    }
}

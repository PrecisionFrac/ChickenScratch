using ChickenScratch.Business;
using ChickenScratch.Model;
using ChickenScratch.Util.Services;
using System;
using System.ServiceModel.Activation;

namespace ChickenScratch.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WS : IWS
    {
        #region Customer
        public Response<Customer> CreateCustomer(Customer customer)
        {
            Response<Customer> response = null;
            CustomerBusiness customerBusiness = null;

            try
            {
                customerBusiness = new CustomerBusiness();
                return customerBusiness.Create(customer);
            }
            catch (Exception ex)
            {
                response = new Response<Customer>(null, ResponseStatus.Error, ex.Message);
            }

            return response;
        }


        public Response<Customer> UpdateCustomer(Customer customer)
        {
            Response<Customer> response = null;
            CustomerBusiness customerBusiness = null;

            try
            {
                customerBusiness = new CustomerBusiness();
                return customerBusiness.Update(customer);
            }
            catch (Exception ex)
            {
                response = new Response<Customer>(null, ResponseStatus.Error, ex.Message);
            }

            return response;
        }

        public Response<Customer> DeleteCustomer(Customer customer)
        {
            Response<Customer> response = null;
            CustomerBusiness customerBusiness = null;

            try
            {
                customerBusiness = new CustomerBusiness();
                return customerBusiness.Delete(customer);
            }
            catch (Exception ex)
            {
                response = new Response<Customer>(null, ResponseStatus.Error, ex.Message);
            }

            return response;
        }

        #endregion Customer
    }
}

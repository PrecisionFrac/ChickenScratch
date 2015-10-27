using ChickenScratch.Model;
using ChickenScratch.Util.Services;
using System.ServiceModel;

namespace ChickenScratch.Services
{
    [ServiceContract]
    public interface IWS
    {
        #region Customer

        [OperationContract]
        Response<Customer> CreateCustomer(Customer customer);

        //[OperationContract]
        //Response<Customer> UpdateCustomer(Customer customer);
        
        //[OperationContract]
        //Response<Customer> DeleteCustomer(Customer customer);

        #endregion Customer
    }
}
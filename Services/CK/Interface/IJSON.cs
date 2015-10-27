using ChickenScratch.Model;
using ChickenScratch.Util.Services;
using PayPal.Api;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ChickenScratch.Services
{
    [ServiceContract]
    public interface IJSON
    {
        #region Customer

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/json/customer/create/")]
        Response<Model.Customer> CreateCustomer(Model.Customer customer);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //   ResponseFormat = WebMessageFormat.Json,
        //   RequestFormat = WebMessageFormat.Json,
        //   BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //   UriTemplate = "/api/json/v1/customer/update/")]
        //Response<Customer> UpdateCustomer(Customer customer);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //   ResponseFormat = WebMessageFormat.Json,
        //   RequestFormat = WebMessageFormat.Json,
        //   BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //   UriTemplate = "/api/json/v1/customer/delete/")]
        //Response<Customer> DeleteCustomer(Customer customer);

        #endregion Customer

        #region Address

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/json/address/create/")]
        Response<Model.Address> CreateAddress(Model.Address address);

        #endregion Address

        #region Paypal

        #region Payment 
        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         UriTemplate = "/api/json/v1/paypal/CreatePayment/")]
        //UriTemplate = "api/paypal/CreatePayment/{intent}/{number}/{expireMonth}/{expireYear}/{paymentMethod}")]
        //Response<Payment> CreatePayment(String intent, String number, String expireMonth, String expireYear, String paymentMethod, Collection<String> currency, Collection<String> total);
        Response<PayPal.Api.Payment> CreatePayment(PayPal.Api.Payment payment);
        //Response<Payment> CreatePayment(String intent, String number, String expireMonth, String expireYear, String paymentMethod, Collection<String> currency, Collection<String> total);

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "/v1/paypal/GetPayment/{codePayment}")]
        Response<PayPal.Api.Payment> GetPayment(String codePayment);

        #endregion Payment 

        #region CreditCard

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedRequest,
          UriTemplate = "/api/json/v1/paypal/CreateCreditCard/")]
        Response<CreditCard> CreateCreditCard(CreditCard creditCard);

        #endregion CreditCard

        #endregion Paypal        
    }
}
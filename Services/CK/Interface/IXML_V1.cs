using ChickenScratch.Util.Services;
using PayPal.Api;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ChickenScratch.Services
{
    [ServiceContract]
    public interface IXML_V1
    {
        #region Paypal

        #region Payment 
        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Xml,
         RequestFormat = WebMessageFormat.Xml,
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         UriTemplate = "/api/xml/v1/paypal/CreatePayment/")]
        //UriTemplate = "api/paypal/CreatePayment/{intent}/{number}/{expireMonth}/{expireYear}/{paymentMethod}")]
        //Response<Payment> CreatePayment(String intent, String number, String expireMonth, String expireYear, String paymentMethod, Collection<String> currency, Collection<String> total);
        Response<Payment> CreatePayment(Payment payment);
        //Response<Payment> CreatePayment(String intent, String number, String expireMonth, String expireYear, String paymentMethod, Collection<String> currency, Collection<String> total);

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Xml,
           RequestFormat = WebMessageFormat.Xml,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "/api/xml/v1/paypal/GetPayment/{codePayment}")]
        Response<Payment> GetPayment(String codePayment);

        #endregion Payment 

        #region CreditCard

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Xml,
          RequestFormat = WebMessageFormat.Xml,
          BodyStyle = WebMessageBodyStyle.WrappedRequest,
          UriTemplate = "/api/xml/v1/paypal/CreateCreditCard/")]
        Response<CreditCard> CreateCreditCard(CreditCard creditCard);

        #endregion CreditCard

        #endregion Paypal        
    }
}
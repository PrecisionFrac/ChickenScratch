using ChickenScratch.Business;
using ChickenScratch.Model;
using ChickenScratch.Model.PayPal;
using ChickenScratch.Util.Services;
using PayPal.Api;
using System;
using System.ServiceModel.Activation;

namespace ChickenScratch.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class API : IAPI
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

        #endregion Customer

        #region PayPal
        public Response<PayPal.Api.CreditCard> CreateCreditCard(PayPal.Api.CreditCard creditCard)
        {
            Response<CreditCard> response = null;
            CreditCardBusiness creditCardBusiness = null;
            PayPal<CreditCard> paypal = null;

            try
            {
                creditCardBusiness = new CreditCardBusiness();
                paypal = creditCardBusiness.Create(creditCard);
                response = new Response<CreditCard>(creditCard, ResponseStatus.Success, "Success");
            }
            catch (Exception ex)
            {
                response = new Response<CreditCard>(null, ResponseStatus.Error, ex.Message);
            }

            return response;
        }

        public Response<PayPal.Api.Payment> CreatePayment(PayPal.Api.Payment payment)
        {
            Response<PayPal.Api.Payment> response = null;
            PaymentBusiness paymentBusiness = null;
            PayPal<PayPal.Api.Payment> paypal = null;
            try
            {
                paymentBusiness = new PaymentBusiness();
                paypal = paymentBusiness.Create(payment);
                response = new Response<PayPal.Api.Payment>(paypal.Object, ResponseStatus.Success, "Success");
            }
            catch (Exception ex)
            {
                response = new Response<PayPal.Api.Payment>(null, ResponseStatus.Error, ex.Message);
            }

            return response;
        }

        public Response<PayPal.Api.Payment> GetPayment(String codePayment)
        {
            Response<PayPal.Api.Payment> response = null;
            PaymentBusiness paymentBusiness = null;

            try
            {
                paymentBusiness = new PaymentBusiness();
                PayPal<PayPal.Api.Payment> paypal = paymentBusiness.Get(codePayment);

                if (paypal.IsValid)
                    response = new Response<PayPal.Api.Payment>(paypal.Object, ResponseStatus.Success, "Success");
                else
                {
                    response = new Response<PayPal.Api.Payment>(paypal.Object, ResponseStatus.ErrorValidation, "Success");
                    response.Validations = paypal.Validations;
                }
            }
            catch (Exception ex)
            {
                response = new Response<PayPal.Api.Payment>(null, ResponseStatus.Error, ex.Message);
            }

            return response;
        }

        #endregion Paypal
    }
}

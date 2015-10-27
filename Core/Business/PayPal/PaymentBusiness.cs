using ChickenScratch.Data.PayPal;
using ChickenScratch.Model.PayPal;
using PayPal.Api;
using System;
using System.Collections.Generic;

namespace ChickenScratch.Business
{
    public class PaymentBusiness : PayPalBusinessBase
    {
        public PaymentBusiness()
        {
        }

        /// <summary>
        /// https://developer.paypal.com/docs/api/#create-a-payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public PayPal<Payment> Create(Payment payment)
        {
            PayPal<Payment> paypal = new PayPal<Payment>();

            try
            {
                PaymentRepository paymentRepository = new PaymentRepository();

                if (System.Diagnostics.Debugger.IsAttached)
                    payment = DEBUG_Create();

                paypal.Object = paymentRepository.Create(payment);

                return paypal;
            }
            catch (PayPal.HttpException he)
            {
                //{"name":"INVALID_RESOURCE_ID","message":"The requested resource ID was not found","information_link":"https://developer.paypal.com/webapps/developer/docs/api/#INVALID_RESOURCE_ID","debug_id":"e035690ac842e"}
                if (he.Response.Contains("INVALID_RESOURCE_ID"))
                {
                    paypal.Validations.Add("paymentCode", "Invalid ID");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return paypal;
        }

        private Payment DEBUG_Create()
        {
            Payment payment = new Payment();

            FundingInstrument fundingInstrument = new FundingInstrument()
            {
                credit_card = new CreditCard()
                {
                    number = "4032036390019741",
                    type = "visa",
                    expire_month = 11,
                    expire_year = 2020
                }
            };

            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            fundingInstruments.Add(fundingInstrument);

            payment = new Payment()
            {
                intent = "sale",
                payer = new Payer()
                {
                    payment_method = "credit_card",
                    funding_instruments = fundingInstruments
                }
            };

            return payment;
        }

        public PayPal<Payment> Get(String paymentCode)
        {
            PayPal<Payment> paypal = new PayPal<Payment>();

            try
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                paypal.Object = paymentRepository.Get(paymentCode);
                return paypal;
            }
            catch (PayPal.HttpException he)
            {
                //{"name":"INVALID_RESOURCE_ID","message":"The requested resource ID was not found","information_link":"https://developer.paypal.com/webapps/developer/docs/api/#INVALID_RESOURCE_ID","debug_id":"e035690ac842e"}
                if (he.Response.Contains("INVALID_RESOURCE_ID"))
                {
                    paypal.Validations.Add("paymentCode", "Invalid ID");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return paypal;
        }
    }
}

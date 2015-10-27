using ChickenScratch.Model.PayPal;
using PayPal.Api;
using System;

namespace ChickenScratch.Business
{
    public class CreditCardBusiness : PayPalBusinessBase
    {
        public CreditCardBusiness()
        {

        }

        public PayPal<CreditCard> Create(CreditCard creditCard)
        {
            PayPal<CreditCard> paypal = new PayPal<CreditCard>();

            try
            {
                creditCard = new CreditCard()
                {
                    number = "4032035304110067",
                    type = "visa",
                    expire_month = 11,
                    expire_year = 2020,
                    cvv2 = "4960",
                    first_name = "Rafael",
                    last_name = "Aguiar",
                    billing_address = new Address()
                    {
                        phone = "1231231",
                        line1 = "1 First Street",
                        city = "Saratoga",
                        state = "CA",
                        postal_code = "95070",
                        country_code = "US"
                    }
                };

                paypal.Object = creditCard;

                return paypal;
            }
            catch (PayPal.HttpException he)
            {
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

        public CreditCard GetFake()
        {
            CreditCard creditCard = new CreditCard()
            {
                number = "4032035304110067",
                type = "visa",
                expire_month = 11,
                expire_year = 2020,
                cvv2 = "496",
                first_name = "Rafael",
                last_name = "Aguiar",
                billing_address = new Address()
                {
                    phone = "1231231",
                    line1 = "1 First Street",
                    city = "Saratoga",
                    state = "CA",
                    postal_code = "95070",
                    country_code = "US"
                }
            };

            return creditCard;
        }
    }
}

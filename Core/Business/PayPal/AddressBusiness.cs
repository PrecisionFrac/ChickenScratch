using ChickenScratch.Model.PayPal;
using PayPal.Api;
using System;

namespace ChickenScratch.Business
{
    public class AddressBusiness : PayPalBusinessBase
    {
        public AddressBusiness()
        {

        }

        public PayPal<Address> Create(Address address)
        {
            PayPal<Address> paypal = new PayPal<Address>();

            try
            {
                address = new Address()
                {
                    normalization_status = "adasd",
                    phone = "1231231",
                    status = "OK",
                    line2 = "",
                    line1 = "1 First Street",
                    city = "Saratoga",
                    state = "CA",
                    postal_code = "95070",
                    country_code = "US"
                };

                paypal.Object = address;

                return paypal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

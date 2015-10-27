using PayPal.Api;
using System;

namespace ChickenScratch.Data.PayPal
{
    public class PaymentRepository : PayPalRepository
    {
        public PaymentRepository()
            : base()
        {

        }

        public Payment Create(Payment payment)
        {
            return Payment.Create(context, payment);
        }

        public Payment Get(String paymentCode)
        {
            return Payment.Get(context, paymentCode);
        }
    }
}

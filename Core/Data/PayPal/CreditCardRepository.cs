using PayPal.Api;

namespace ChickenScratch.Data.PayPal
{
    public class CreditCardRepository : PayPalRepository
    {
        public CreditCardRepository()
        {
            this.Connect();
        }

        public CreditCard Create(CreditCard creditCard)
        {
            return CreditCard.Create(context, creditCard);
        }
    }
}

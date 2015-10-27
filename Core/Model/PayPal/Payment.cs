using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChickenScratch.Model
{
    public class Payment
    {
    //    Dictionary<String, String> validations = new Dictionary<string, string>();

    //        // Validation
    //        if (payment == null)
    //        {
    //            throw new Exception("Object is null");
    //}

    //        if (payment.intent.Trim() == String.Empty || payment.intent.Trim() != "sale")
    //        {
    //            validations.Add("intent", "Empty or different value (sale, authorize or order)");
    //        }

    //        if (payment.payer == null)
    //        {
    //            validations.Add("payer", "null");
    //        }
    //        else if (payment.payer.payment_method == String.Empty
    //            || payment.payer.payment_method != "credit_card"
    //            || payment.payer.payment_method != "paypal") // PayPal account or a credit card
    //        {
    //            validations.Add("payer", "Empty or different value (credit_card or paypal)");
    //        }

    //        if (payment.transactions == null || payment.transactions.Count == 0)
    //        {
    //            validations.Add("transactions", "Empty");
    //        }
    //        else
    //        {
    //            // Validation - Transactions
    //            foreach (Transaction transaction in payment.transactions)
    //            {
    //                if (transaction.amount == null)
    //                {
    //                }

    //                if (transaction.amount.currency.Trim() == String.Empty)
    //                {
    //                    validations.Add("Transaction", "Empty");
    //                }

    //                if (transaction.amount.total)
    //                {
    //                    validations.Add("", "");
    //                }
    //            }

    //        }
    }

    [DataContract]
    public enum Intent : short
    {
        // immediate payment
        [EnumMember]
        sale = 1,

        // authorize a payment for capture 
        [EnumMember]
        authorize = 2,

        // create an order
        [EnumMember]
        order = 3
    }
}

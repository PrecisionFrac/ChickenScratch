using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChickenScratch.Model.PayPal
{
    public class PayPalValidation
    {
        public static PayPalValidation CreateVal<E>(E ex)
        {
            PayPalValidation payPalValidation = new PayPalValidation();

            if (ex is Exception)
            {

            }

            return payPalValidation;
        }
    }
}

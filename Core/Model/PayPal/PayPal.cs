using System;
using System.Collections.Generic;

namespace ChickenScratch.Model.PayPal
{
    public class PayPal<T>
    {
        public PayPal()
        {
            this.Validations = new Dictionary<string, string>();
        }

        public T Object { get; set; }

        public Dictionary<String, String> Validations { get; set; }

        public Boolean IsValid
        {
            get
            {
                if (this.Validations.Count > 0)
                    return false;
                return true;
            }
            private set { }
        }
    }
}

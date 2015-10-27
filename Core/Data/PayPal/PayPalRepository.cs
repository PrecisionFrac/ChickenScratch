using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenScratch.Data.PayPal
{
    public abstract class PayPalRepository : RepositoryBase
    {
        protected Dictionary<String, String> config = null;
        protected String accessToken = String.Empty;
        protected APIContext context = null;

        public PayPalRepository()
        {
            this.Connect();
        }

        /// <summary>
        /// Connect in PayPal and generate the TOKEN.
        /// </summary>
        protected void Connect()
        {
            config = ConfigManager.Instance.GetProperties();
            accessToken = new OAuthTokenCredential(config).GetAccessToken();

            context = new APIContext(accessToken);

            // Define any HTTP headers to be used in HTTP requests made with this APIContext object
            if (context.HTTPHeaders == null)
                context.HTTPHeaders = new Dictionary<String, String>();

            context.HTTPHeaders["XX-Company"] = "ChickenScratch";
        }
    }
}

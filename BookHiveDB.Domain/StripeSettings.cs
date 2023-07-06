using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Domain
{
    public class StripeSettings
    {
        public string PublishableKey { get; set; }
        public string SecretKey { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.AISHelper
{
    public class NewBillingArgs
    {
        public NewBilling_insured insured { get; set; }
        public NewBilling_agent agent { get; set; }
        public NewBilling_account account { get; set; }
        public IEnumerable<NewBilling_policies> policies { get; set; }
    }
}

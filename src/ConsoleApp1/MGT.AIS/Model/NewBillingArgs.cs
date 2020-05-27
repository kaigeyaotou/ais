using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class NewBillingArgs
    {
        /// <summary>
        /// Information of the Insured(Policyholder) to be setup with a premium finance loan account
        /// </summary>
        public NewBilling_insured insured { get; set; }
        /// <summary>
        /// Information of the Agent who wrote the insurance policy being setup for a premium finance loan account
        /// </summary>
        public NewBilling_agent agent { get; set; }
        /// <summary>
        /// Billing information of the Insured to be setup with a premium finance loan account
        /// </summary>
        public NewBilling_account account { get; set; }
        /// <summary>
        /// Policy Information of the premium finance loan account. This is an array and the length of the array is set to 8
        /// </summary>
        public IEnumerable<NewBilling_policies> policies { get; set; }
    }
}

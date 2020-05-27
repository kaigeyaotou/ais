using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class AddPreminumFinanceArgs
    {
        /// <summary>
        /// Information of the Insured(Policyholder) to generate premium finance agreement
        /// </summary>
        public AddPreminumFinance_insured insured { get; set; }
        /// <summary>
        /// Information of the Agent who wrote the insurance policy to generate premium finance agreement
        /// </summary>
        public AddPreminumFinance_agent agent { get; set; }
        /// <summary>
        /// Billing Information of the Insured for generate premium finance agreement
        /// </summary>
        public AddPreminumFinance_account account { get; set; }
        /// <summary>
        /// Policy Information of the Insured for generate premium finance agreement. This is an array and the length of the array is set to 8
        /// </summary>
        public IEnumerable<AddPreminumFinance_policy> policies   { get; set; }
    }
}

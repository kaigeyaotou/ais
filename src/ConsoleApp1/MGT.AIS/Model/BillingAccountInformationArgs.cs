using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class BillingAccountInformationArgs
    {
        /// <summary>
        /// Billing account number assigned by AIS. "aisAccountNumber" is required to retrieve the billing account information without "insuredId" and "policyNumber". Max length 8
        /// </summary>
        public string aisAccountNumber { get; set; }
        /// <summary>
        /// ID assigned to Insured using client's identifier from their system. Both "insuredId" and "policyNumber" is required to retrieve the billing account information without "aisAccountNumber". Max length 12
        /// </summary>
        public string insuredId { get; set; }
        /// <summary>
        /// Policy number of the policy. Both "insuredId" and "policyNumber" is required to retrieve the billing account information without "aisAccountNumber". Max length 30
        /// </summary>
        public string policyNumber { get; set; }
        /// <summary>
        /// Retrieve the account information including all the policy information? (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        public string policyFlag { get; set; }
    }
}

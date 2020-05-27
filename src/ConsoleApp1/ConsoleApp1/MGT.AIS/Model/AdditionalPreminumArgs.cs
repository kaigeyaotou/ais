using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class AdditionalPreminumArgs
    {
        /// <summary>
        /// ID assigned to Insured using client's identifier from their system. Max length 12
        /// </summary>
        [Required]
        public string insuredId { get; set; }
        /// <summary>
        /// Business name of the Insured if commercial lines insurance coverage. Last name of the Insured if personal lines insurance coverage. Max length 30
        /// </summary>
        public string insuredName1 { get; set; }
        /// <summary>
        /// Billing account number assigned by AIS. Max length 8
        /// </summary>
        [Required]
        public string aisAccountNumber { get; set; }
        /// <summary>
        /// Note to explain additional premium endorsement. Note will appear on the Notice of Amended Payment Schedule sent to the insured and agent and in the note file on the customer inquiry. Max length 75
        /// </summary>
        public string note1 { get; set; }
        /// <summary>
        /// Additional Note to explain additional premium endorsement. Note will appear on the Notice of Amended Payment Schedule sent to the insured and agent and in the note file on the customer inquiry. Max length 75
        /// </summary>
        public string note2 { get; set; }
        /// <summary>
        /// Policy Information of the premium finance loan account. This is an array and the length of array is set to 8. Can be request additional premium endorsements for a premium finance loan account. Also new policy setup for a premium finance loan account can be done if required.
        /// </summary>
        public IEnumerable<AdditionalPreminum_policy> policies { get; set; }
    }
}

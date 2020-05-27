using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class PolicyReinStatementArgs
    {
        /// <summary>
        /// ID assigned to Insured using client's identifier from their system. Max length 12
        /// </summary>
        public string insuredId { get; set; }
        /// <summary>
        /// Billing account number assigned by AIS. Max length 8
        /// </summary>
        public string aisAccountNumber { get; set; }
        /// <summary>
        /// Note to explain reinstatment request. Note will appear on the Notice of Amended Payment Schedule sent to the Insured and agent and in the note file on the customer inquiry. Max length 75
        /// </summary>
        public string note1 { get; set; }
        /// <summary>
        /// Additional Note to explain reinstatment request. Note will appear on the Notice of Amended Payment Schedule sent to the Insured and agent and in the note file on the customer inquiry. Max length 75
        /// </summary>
        public string note2 { get; set; }
        /// <summary>
        /// "agentCodeCrossReference" is the code used by the client to identify the agent on their system. This needs to be setup in the AIS system first. "agentCodeCrossReference" is required when the "agentCode" is not available. Max length 12
        /// </summary>
        public string agentCodeCrossReference { get; set; }
        /// <summary>
        /// "agentCode" is the code used to identify the agent and it is supplied by AIS. "agentCode" is required when the "agentCodeCrossReference" not available. Max length 6
        /// </summary>
        public string agentCode { get; set; }
        /// <summary>
        /// Effective date of reinstatement of the insurance policy(Format: MMDDYYYY). Max length 8
        /// </summary>
        [Required]
        public string reinstateDate { get; set; }
        /// <summary>
        /// Are all insurance policies reinstated? If yes Valid Value: "A"=Account. If an individual policy is reinstated and there are multiple policies on a billing account, Valid Value: "P"=Policy. Max length 1
        /// </summary>
        [Required]
        public string reinstateType { get; set; }
        /// <summary>
        /// Who requested the reinstatement of the insurance policy (Valid Values: "A"=Agent, "I"=Insurance Company). Max length 1
        /// </summary>
        [Required]
        public string requestedBy { get; set; }
        /// <summary>
        /// Policy Information of the premium finance loan account. This is an array and the length of the array is set to 8. Can be reinstate cancelled policies in a premium finance loan account
        /// </summary>
        public IEnumerable<PolicyReinStatement_policy> policies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class PolicyCancellationArgs
    {
        /// <summary>
        /// ID assigned to Insured using client's identifier from their system. Max length 12
        /// </summary>
        public string insuredId { get; set; }
        /// <summary>
        /// Billing account number assigned by AIS. Max length 8
        /// </summary>
        [Required]
        public string aisAccountNumber { get; set; }
        /// <summary>
        /// Note to explain reason for cancellation. Note will appear on the Notice of Amended Payment Schedule sent to the insured and agent and in the note file on the customer inquiry. Max length 75
        /// </summary>
        public string note1 { get; set; }
        /// <summary>
        /// Additional Note to explain reason for cancellation. Note will appear on the Notice of Amended Payment Schedule sent to the insured and agent and in the note file on the customer inquiry. Max length 75
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
        /// Effective date of cancellation of the policy (Format: MMDDYYYY). Max length 8
        /// </summary>
        [Required]
        public string cancellationDate { get; set; }
        /// <summary>
        /// Are all policies to be cancelled? If yes Valid Value: "A"=Account. If an individual policy to be cancelled and there are multiple policies on a billing account then Value: "P"=Policy. (To do this there should be at least one active policy remaining in the billing account after policy cancellation). Max length 1
        /// </summary>
        [Required]
        public string cancellationType { get; set; }
        /// <summary>
        /// Who requested cancellation of the policy (Valid Values: "A"=Agent, "I"=Insurance Company, "B"=Borrower/Insured). Max length 1
        /// </summary>
        [Required]
        public string requestedBy { get; set; }
        /// <summary>
        /// Policy Information of the premium finance loan account. This is an array and the length of the array is set to 8. Active policies can only be cancelled.
        /// </summary>
        public IEnumerable<PolicyCancellation_policy> policies { get; set; }
    }
}

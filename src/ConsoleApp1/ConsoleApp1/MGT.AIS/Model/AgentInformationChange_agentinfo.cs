using System.ComponentModel.DataAnnotations;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Information of the Agent who wrote the insurance policy being setup for a premium finance loan
    /// </summary>
    public class AgentInformationChange_agentinfo
    {
        /// <summary>
        /// "agentCodeCrossReference" is the code used by the client to identify the agent on their system. This needs to be setup in the AIS system first. "agentCodeCrossReference" is required when the "agentCode" is not available. Max length 12
        /// </summary>
        public string agentCodeCrossReference { get; set; }
        /// <summary>
        /// "agentCode" is the code used to identify the agent and it is supplied by AIS. "agentCode" is required when the "agentCodeCrossReference" not available. Max length 6
        /// </summary>
        public string agentCode { get; set; }
        /// <summary>
        /// Agent Information to be added or changed (Valid Values: "A"=ADD or "C"=CHANGE). Max length 1
        /// </summary>
        [Required]
        public string agentRequestType { get; set; }
        /// <summary>
        /// Agent name change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string agentNameChangeFlag { get; set; }
        /// <summary>
        /// Agent name to be changed. Max length 30
        /// </summary>
        [Required]
        public string agentName { get; set; }
        /// <summary>
        /// Agent address change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string agentAddressChangeFlag { get; set; }
        /// <summary>
        /// Agent address to be changed. Agent address is required if agentAddressChangeFlag set to "Y". Max length 30
        /// </summary>
        [Required]
        public string agentAddress { get; set; }
        /// <summary>
        /// Agent city to be changed. Agent city is required if agentAddressChangeFlag set to "Y". Max length 22
        /// </summary>
        [Required]
        public string agentCity { get; set; }
        /// <summary>
        /// Agent state to be changed. Agent state is required if agentAddressChangeFlag set to "Y". Max length 2
        /// </summary>
        [Required]
        public string agentState { get; set; }
        /// <summary>
        /// Agent zip code to be changed. Agent zip code is required if agentAddressChangeFlag set to "Y". Max length 5
        /// </summary>
        [Required]
        public string agentZipCode { get; set; }
        /// <summary>
        /// Agent phone change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string agentPhoneChangeFlag { get; set; }
        /// <summary>
        /// Agent phone number to be changed. Max length 10
        /// </summary>
        public string agentPhoneNumber { get; set; }
        /// <summary>
        /// Agent fax number change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string agentFaxChangeFlag { get; set; }
        /// <summary>
        /// Agent fax number to be changed. Max length 10
        /// </summary>
        public string agentFaxNumber { get; set; }
        /// <summary>
        /// Agent email address change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string agentEmailChangeFlag { get; set; }
        /// <summary>
        /// Agent email address to be changed. Max length 10
        /// </summary>
        public string agentEmailAddress { get; set; }
        /// <summary>
        /// Agent mail option change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string agentMailOptionChangeFlag { get; set; }
        /// <summary>
        /// Agent correspondence to be sent by fax, email or through USPS (Valid Values: "F"=Fax, "E"=Email, Blank=Regular Mail). Max length 1
        /// </summary>
        public string agentMailOptionFlag { get; set; }
        /// <summary>
        /// Agent Social Security Number / Federal Id number change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string agentSSNFederalIdChangeFlag { get; set; }
        /// <summary>
        /// Agent Social Security Number / Federal ID Number (Valid Values: "S"=SSN, "F"=Federal ID). Max length 1
        /// </summary>
        public string agentSSNFederalIdTypeFlag { get; set; }
        /// <summary>
        /// Agent Social Security Number or Federal ID Number. Max length 9
        /// </summary>
        public string agentSSNFederalId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class InsuredInformationCHnage_result
    {
        public InsuredInformationCHnage_resultEntity results { get; set; }
    }
    public class InsuredInformationCHnage_resultEntity
    {
        /// <summary>
        /// System generated unique identifier to identify the response of Insured name and address change request. Max length 11
        /// </summary>
        public string responseReference { get; set; }
        /// <summary>
        /// Status of Insured information change request(Valid Values: Accepted or Rejected). Max length 8
        /// </summary>
        public string processingStatus { get; set; }
        /// <summary>
        /// System Generated. Max length 4
        /// </summary>
        public string returnCode { get; set; }
        /// <summary>
        /// System Generated. Max length 255
        /// </summary>
        public string returnMessage { get; set; }
        /// <summary>
        /// Transaction Processed Date and Time. System Generated (Format: MM/DD/YYYY HH:MM:SS). Max length 20
        /// </summary>
        public string processedDateTime { get; set; }
        /// <summary>
        /// Transaction Processed Date. System Generated (Format: MMDDYYYY). Max length 8
        /// </summary>
        public string processedDate { get; set; }
        /// <summary>
        /// Transaction Processed Time. System Generated (Format: HHMMSSNN). Max length 8
        /// </summary>
        public string processedTime { get; set; }
        /// <summary>
        /// Premium finance company code assigned by AIS. Max length 3
        /// </summary>
        public string premiumFinanceCompanyCode { get; set; }
        /// <summary>
        /// Billing Account Number assigned by AIS. Max length 8
        /// </summary>
        public string aisAccountNumber { get; set; }
        /// <summary>
        /// "agentCodeCrossReference" is the code used by the client to identify the agent on their system. This needs to be setup in the AIS system first. Max length 12
        /// </summary>
        public string agentCodeCrossReference { get; set; }
        /// <summary>
        /// "agentCode" is the code used to identify the agent and it is supplied by AIS. Max length 6
        /// </summary>
        public string agentCode { get; set; }
        /// <summary>
        /// ID assigned to Insured using client's identifier from their system. Max length 12
        /// </summary>
        public string insuredId { get; set; }
    }
}

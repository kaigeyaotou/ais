using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class BillingAccountInformation_result
    {
        public BillingAccountInformationEntity results { get; set; }
    }
    public class BillingAccountInformationEntity
    {
        /// <summary>
        /// System generated unique identifier to identify the response of billing account information request. Max length 11
        /// </summary>
        public string responseReference { get; set; }
        /// <summary>
        /// Status of billing account information request (Valid Values: Accepted or Rejected). Max length 8
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
        /// Billing account number assigned by AIS. Max length 8
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
        /// <summary>
        /// Business name of the Insured if commercial lines insurance coverage. Last name of the Insured if personal lines insurance coverage. Max length 30
        /// </summary>
        public string insuredName1 { get; set; }
        /// <summary>
        /// Second business name of the Insured if commercial lines coverage. First name of the Insured if personal lines coverage. Max length 30
        /// </summary>
        public string insuredName2 { get; set; }
        /// <summary>
        /// Street address of the insured. Max length 30
        /// </summary>
        public string insuredAddress1 { get; set; }
        /// <summary>
        /// Street address of the Insured continued (if required). Max length 30
        /// </summary>
        public string insuredAddress2 { get; set; }
        /// <summary>
        /// City of the Insured. Max length 23
        /// </summary>
        public string insuredCity { get; set; }
        /// <summary>
        /// State of the Insured (2 digit state abbreviation). Max length 2
        /// </summary>
        public string insuredState { get; set; }
        /// <summary>
        /// Zip code of the Insured (5 digit). Max length 5
        /// </summary>
        public string insuredZip { get; set; }
        /// <summary>
        /// Total policy premium including all taxes and applicable fees. Max length 11
        /// </summary>
        public string totalPremiumAmount { get; set; }
        /// <summary>
        /// Total down payment including policy premium and non-refundable taxes and fees to be collected with policy premium down payment. Max length 11
        /// </summary>
        public string totalDownpayAmount { get; set; }
        /// <summary>
        /// Policy unpaid balance (totalAccountBalanceAmount = totalPremiumAmount - totalDownpayAmount). Max length 11
        /// </summary>
        public string totalAccountBalanceAmount { get; set; }
        /// <summary>
        /// Number of installment payments for the premium finance loan account. Max length 3
        /// </summary>
        public string paymentTerm { get; set; }
        /// <summary>
        /// Installment amount due (paymentAmount = totalAccountBalanceAmount / paymentTerm). Max length 11
        /// </summary>
        public string paymentAmount { get; set; }
        /// <summary>
        /// Billing account setup business day(Format: MM/DD/YYYY). Max length 10
        /// </summary>
        public string billingAccountSetupDate { get; set; }
        /// <summary>
        /// Next payment due date (Format: MM/DD/YYYY). Max length 10
        /// </summary>
        public string nextPaymentDueDate { get; set; }
        /// <summary>
        /// Next payment due amount. Max length 11
        /// </summary>
        public string nextPaymentDueAmount { get; set; }
        /// <summary>
        /// Installment billing service fee. Max length 5
        /// </summary>
        public string installmentBillingServiceFee { get; set; }
        /// <summary>
        /// Policy Information of the Insured to be setup with a billing account
        /// </summary>
        public BillingAccountPolicy billingAccountPolicy { get; set; }
    }
}

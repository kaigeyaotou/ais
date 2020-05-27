using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class AddPreminumFinanceResult
    {
        /// <summary>
        /// Response of the Generate Premium Finance Agreement Request
        /// </summary>
        public AddPreminumFinanceResultEntity results { get; set; }
    }
    public class AddPreminumFinanceResultEntity
    {
        /// <summary>
        /// System generated unique identifier to identify the response of new premium finance agreement request. Max length 11
        /// </summary>
        public string responseReference { get; set; }
        /// <summary>
        /// Status of billing account setup (Valid Values: Accepted or Rejected). Max length 8
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
        //public string premiumFinanceCompanyCode { get; set; }
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
        /// Total policy premium including all taxes and applicable fees. Max length 11
        /// </summary>
        public string totalPremiumAmount { get; set; }
        /// <summary>
        /// Total down payment including policy premium and non-refundable taxes and fees to be collected with policy premium down payment. Max length 11
        /// </summary>
        public string totalDownpayAmount { get; set; }
        /// <summary>
        /// Amount financed (amountFinanced = totalPremiumAmount - totalDownpayAmount). Max length 11
        /// </summary>
        public string amountFinanced { get; set; }
        /// <summary>
        /// Finance charge to be billed to the Insured for the premium finance loan. Max length 11
        /// </summary>
        public string financeCharge { get; set; }
        /// <summary>
        /// Total of Payments including finance charge (totalOfPayments = amountFinanced + financeCharge). Max length 11
        /// </summary>
        public string totalOfPayments { get; set; }
        /// <summary>
        /// Number of installments (not including downpayment). Max length 3
        /// </summary>
        public string numberOfInstallments { get; set; }
        /// <summary>
        /// Insured's installment payment amount (paymentAmount = totalOfPayments / numberOfInstallments). Max length 11
        /// </summary>
        public string paymentAmount { get; set; }
        /// <summary>
        /// Premium finance agreement setup business day (Format: MM/DD/YYYY). Max length 10
        /// </summary>
        public string billingAccountSetupDate { get; set; }
        /// <summary>
        /// Due date of the first installment (Format: MM/DD/YYYY). Max length 10
        /// </summary>
        public string firstPaymentDueDate { get; set; }
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
        /// Annual Percentage Rate from the rate chart or a special rate used. Max length 5
        /// </summary>
        public string originalAPR { get; set; }
        /// <summary>
        /// Recalculated Annual Percentage rate after Addon or Arranger Fee. Max length 5
        /// </summary>
        public string currentAPR { get; set; }
        /// <summary>
        ///  Florida state documentary stamp tax amount.Max length 7
        /// </summary>
        public string stampTax { get; set; }
        /// <summary>
        /// Returns a URL that enables to download the Premium Finance Agreement in PDF format. Max length 100
        /// </summary>
        public string premiumFinanceAgreement { get; set; }
    }
}

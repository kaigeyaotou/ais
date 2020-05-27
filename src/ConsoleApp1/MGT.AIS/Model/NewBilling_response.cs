using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Response of the New Billing Account Setup Request
    /// </summary>
    public class NewBilling_response
    {
        public NewBilling_responseEntity results { get; set; }  
    }
    public class NewBilling_responseEntity
    {
        /// <summary>
        /// System generated unique identifier to identify the response of new billing account setup request. Max length 11
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
        /// <summary>
        /// Premium finance company code assigned by AIS. Max length 3
        /// </summary>
        public string premiumFinanceCompanyCode { get; set; }
        /// <summary>
        /// Billing account number to be assigned by AIS. Max length 8
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
        public string totalDownPayAmount { get; set; }
        /// <summary>
        /// Amount financed (amountFinanced = totalPremiumAmount - totalDownpayAmount). Max length 11
        /// </summary>
        public string amountFinanced { get; set; }
        /// <summary>
        /// Finance charge to be billed to the Insured for the premium finance loan. Max length 11
        /// </summary>
        public string financeCharge { get; set; }
        /// <summary>
        /// Total of payments including finance charge (totalOfPayments = amountFinanced + financeCharge). Max length 11
        /// </summary>
        public string totalOfPayments { get; set; }
        /// <summary>
        /// Number of installments (not including down payment). Max length 3
        /// </summary>
        public int numberOfInstallments { get; set; }
        /// <summary>
        /// Insured's installment payment amount (paymentAmount = totalOfPayments / numberOfInstallments). Max length 11
        /// </summary>
        public string paymentAmount { get; set; }
        /// <summary>
        /// Billing account setup business day(Format: MM/DD/YYYY). Max length 10
        /// </summary>
        public string billingAccountSetupDate { get; set; }
        /// <summary>
        /// Due date of the first installment (Format: MM/DD/YYYY). If "firstPaymentDate" not given, system will calculate it by adding 30 days to the policy inception date. If there are multiple policies earliest inception date will be used. Max length 10
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
        /// Installment billing service fee
        /// </summary>
        public string installmentBillingServiceFee { get; set; }
        /// <summary>
        /// Annual Percentage Rate from the rate chart or a special rate used. Max length 5
        /// </summary>
        public string originalAPR { get; set; }
        /// <summary>
        /// Recalculated Annual Percentage Rate after Addon or Arranger Fee. Max length 5
        /// </summary>
        public string currentAPR { get; set; }
        /// <summary>
        /// Florida state documentary stamp tax amount. Max length 7
        /// </summary>
        public string stampTax { get; set; }
        /// <summary>
        /// Returns a URL that enables to download the Contract Processing Report in PDF format. Max length 100 
        /// </summary>
        public string processingReportLocation { get; set; }
        /// <summary>
        /// Returns a URL that enables to download the Premium Finance Agreement in PDF format. Max length 100
        /// </summary>
        public string premiumFinanceAgreement { get; set; }
        /// <summary>
        /// Returns a URL that enables to download the Collateral Deposit Agreement in PDF Format(If Applicable). Max length 100
        /// </summary>
        public string cdAgreement { get; set; }
        /// <summary>
        /// Producer quote to show the down payment due to the insurance company or General Agent. Max length 100
        /// </summary>
        public string producerQuote { get; set; }
    }
}

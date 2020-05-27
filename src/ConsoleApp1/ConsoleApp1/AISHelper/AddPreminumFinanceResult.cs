using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.AISHelper
{
    public class AddPreminumFinanceResult
    {
        public AddPreminumFinanceResultEntity results { get; set; }
    }
    public class AddPreminumFinanceResultEntity
    {
        public string responseReference { get; set; }
        public string processingStatus { get; set; }
        public string returnCode { get; set; }
        public string returnMessage { get; set; }
        public string processedDateTime { get; set; }
        public string processedDate { get; set; }
        public string processedTime { get; set; }
        public string premiumFinanceCompanyCode { get; set; }
        public string aisAccountNumber { get; set; }
        public string agentCodeCrossReference { get; set; }
        public string agentCode { get; set; }
        public string insuredId { get; set; }
        public string insuredName1 { get; set; }
        public string totalPremiumAmount { get; set; }
        public string totalDownpayAmount { get; set; }
        public string amountFinanced { get; set; }
        public string financeCharge { get; set; }
        public string totalOfPayments { get; set; }
        public string numberOfInstallments { get; set; }
        public string paymentAmount { get; set; }
        public string billingAccountSetupDate { get; set; }
        public string firstPaymentDueDate { get; set; }
        public string nextPaymentDueDate { get; set; }
        public string nextPaymentDueAmount { get; set; }
        public string installmentBillingServiceFee { get; set; }
        public string originalAPR { get; set; }
        public string currentAPR { get; set; }
        public string stampTax { get; set; }
        public string premiumFinanceAgreement { get; set; }
    }
}

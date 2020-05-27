using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.AISHelper
{
    public class BillingAccountInformation
    {
        public BillingAccountInformationEntity results { get; set; }
    }
    public class BillingAccountInformationEntity
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
        public string insuredName2 { get; set; }
        public string insuredAddress1 { get; set; }
        public string insuredAddress2 { get; set; }
        public string insuredCity { get; set; }
        public string insuredState { get; set; }
        public string insuredZip { get; set; }
        public string totalPremiumAmount { get; set; }
        public string totalDownpayAmount { get; set; }
        public string totalAccountBalanceAmount { get; set; }
        public string paymentTerm { get; set; }
        public string paymentAmount { get; set; }
        public string billingAccountSetupDate { get; set; }
        public string nextPaymentDueDate { get; set; }
        public string nextPaymentDueAmount { get; set; }
        public string installmentBillingServiceFee { get; set; }
        public BillingAccountPolicy billingAccountPolicy { get; set; }
    }
}

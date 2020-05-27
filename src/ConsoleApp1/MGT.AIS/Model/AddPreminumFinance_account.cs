using System.ComponentModel.DataAnnotations;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Billing Information of the Insured for generate premium finance agreement
    /// </summary>
    public class AddPreminumFinance_account
    {
        /// <summary>
        /// Insured's policy type (Valid Values: "P"=Personal / Individual, "C"=Commercial / Business). Max length 1
        /// </summary>
        [Required]
        public string accountType { get; set; }
        /// <summary>
        /// Total policy premium including all taxes and applicable fees (Total of policy PremiumAmount, policyFee1Amount, policyFee2Amount, policyFee3Amount, policyFee4Amount). Max length 11
        /// </summary>
        [Required]
        public string totalPremiumAmount { get; set; }
        /// <summary>
        /// Total down payment including policy premium and non-refundable taxes and fees to be collected with policy premium down payment (Total of policy PremiumDownpay, policyFee1AmountDownpay, policyFee2AmountDownpay, policyFee3AmountDownpay, policyFee4AmountDownpay). Max length 11
        /// </summary>
        [Required]
        public string totalDownPayAmount { get; set; }
        /// <summary>
        /// Amount financed (amountFinanced = totalPremiumAmount - totalDownpayAmount). Max length 11
        /// </summary>
        [Required]
        public string amountFinanced { get; set; }
        /// <summary>
        /// If "calculateFinanceChargeFlag" set to "Y"=Yes, system will calculate the finance charge and APR(Whatever values passed in for calculated fields will be ignored). If "calculateFinanceChargeFlag" set to "N"/Blank=No, values for calculated fileds must be passed in (Valid Values: "Y"=Yes, or "N"/Blank=No). Max length 1
        /// </summary>
        public string calculateFinanceChargeFlag { get; set; }
        /// <summary>
        /// Finance charge to be billed to the Insured for the premium finance loan. Required if "calculateFinanceChargeFlag" is set to No (This is a calculated field). Max length 11
        /// </summary>
        public string financeCharge { get; set; }
        /// <summary>
        /// Total of Payments including finance charge (totalOfPayments = amountFinanced + financeCharge). Required if "calculateFinanceChargeFlag" is set to No (This is a calculated field). Max length 11
        /// </summary>
        public string totalOfPayments { get; set; }
        /// <summary>
        /// Insured's premium finance loan account payment intervals. Is billing setup as a Quarterly Payment (to be billed every 3 months) or as a Monthly Payment (Valid Values: Y=Quarterly, N=Monthly). Max length 1
        /// </summary>
        public string quarterlyPaymentFlag { get; set; }
        /// <summary>
        /// Number of installment payments for the premium finance loan account. Max length 3
        /// </summary>
        [Required]
        public string paymentTerm { get; set; }
        /// <summary>
        /// Insured's installment payment amount (paymentAmount = totalOfPayments / paymentTerm). Required if "calculateFinanceChargeFlag" is set to No (This is a calculated field). Max length 11
        /// </summary>
        public string paymentAmount { get; set; }
        /// <summary>
        /// Due date of the first installment (Format: MMDDYYYY). If "firstPaymentDate" not given, system will calculate it using company settings and policy inception date. If there are multiple policies earliest inception date will be used. Max length 8
        /// </summary>
        public string firstPaymentDate { get; set; }
        /// <summary>
        /// Annual Percentage Rate from the rate chart or a special rate used. Required if "calculateFinanceChargeFlag" is set to No (This is a calculated field). Max length 5
        /// </summary>
        public string originalAPR { get; set; }
        /// <summary>
        /// Recalculated Annual Percentage Rate after Addon or Arranger Fee. Required if "calculateFinanceChargeFlag" is set to No (This is a calculated field). Max length 5
        /// </summary>
        public string currentAPR { get; set; }
        /// <summary>
        /// Quote user ID to access rate table assigned by AIS. Max length 12
        /// </summary>
        public string quoteUser { get; set; }
        /// <summary>
        /// Arrangers fee added to the APR to be paid to the producer on the premium finance loan (A=Addon, S=Special). Required if "calculateFinanceChargeFlag" is set to No (This is a calculated field). Max length 1
        /// </summary>
        public string brokerFeeAddonFlag { get; set; }
        /// <summary>
        /// Arrangers fee to be paid to the producer on the premium finance loan or Addon Amount which is an amount allowable by premium finance statute to be added to the APR as a one-time setup charge. Required if "calculateFinanceChargeFlag" is set to No (This is a calculated field). Max length 9
        /// </summary>
        public string brokerFeeAddonAmount { get; set; }
        /// <summary>
        /// N/A. Required if "calculateFinanceChargeFlag" is set to "Y"=Yes. Max length 9
        /// </summary>
        public string policyBrokerFees { get; set; }
        /// <summary>
        /// Florida state documentary stamp tax required for Florida licensed premium finance companies and if the Insured's address is located in Florida(Valid Values: "Y"=Florida state account, or "N"/Blank=Not a Florida state account). Max length 1
        /// </summary>
        [Required]
        public string floridaAccountFlag { get; set; }
        /// <summary>
        /// Florida state documentary stamp tax amount. Required if "floridaAccountFlag" is set to "Y"(Florida state account) and "calculateFinanceChargeFlag" is set to No (This is a calcualed field). Max length 7
        /// </summary>
        public string stampTax { get; set; }
        /// <summary>
        /// Quote number to be assigned by client. Max length 8
        /// </summary>
        public string quoteNumber { get; set; }
        /// <summary>
        /// Billing fee to be charged to the Insured on a monthly basis. Max length 5
        /// </summary>
        public string billingFee { get; set; }
        /// <summary>
        /// Whether the premium finance loan is setup as a continuous pay or continuous billing account. On a continuous pay account Insured will be billed after loan paid off on a monthly basis until the renewal. If a continuous bill account insured will pay a down payment to be kept in escrow for future year's renewals("C"=Continuous Pay)
        /// </summary>
        public string billingType { get; set; }

    }
}
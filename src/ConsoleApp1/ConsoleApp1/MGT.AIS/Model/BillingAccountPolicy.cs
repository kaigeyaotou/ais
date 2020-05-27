namespace MGT.AIS.AISHelper
{
    public class BillingAccountPolicy
    {
        /// <summary>
        /// Assigned by AIS. Max length 2
        /// </summary>
        public string policySequenceNumber { get; set; }
        /// <summary>
        /// Policy number of the policy. Max length 30
        /// </summary>
        public string policyNumber { get; set; }
        /// <summary>
        /// Inception Date (Effective Date) of the policy(Format: MMDDYYYY). Max length 8
        /// </summary>
        public string policyInceptionDate { get; set; }
        /// <summary>
        /// The period of coverage provided by the policy in months (If 12 month policy policyTerm is 12). Max length 2
        /// </summary>
        public string policyTerm { get; set; }
        /// <summary>
        /// "policyInsuranceCompanyNumber" is the code used to identify insurance company which is supplied by AIS. Max length 4
        /// </summary>
        public string policyInsuranceCompanyNumber { get; set; }
        /// <summary>
        /// Name of the Insurance company on the policy. Max length 30
        /// </summary>
        public string policyInsuranceCompanyName { get; set; }
        /// <summary>
        /// "policyCoverageTypeCode" is the code used to identify the policy coverage type which is supplied by AIS. Max length 2
        /// </summary>
        public string policyCoverageTypeCode { get; set; }
        /// <summary>
        /// Policy coverage description. Max length 18
        /// </summary>
        public string policyCoverageDescription { get; set; }
        /// <summary>
        /// Description of the policy. Max length 30
        /// </summary>
        public string policyPremiumDescription { get; set; }
        /// <summary>
        /// Policy Premium Amount. Max length 11
        /// </summary>
        public string policyPremiumAmount { get; set; }
        /// <summary>
        /// Policy Premium Down Payment. Max length 11
        /// </summary>
        public string policyPremiumDownpay { get; set; }
        /// <summary>
        /// Policy Unpaid Premium Amount = Policy Premium Amount - Policy Premium Down payment. Max length 11
        /// </summary>
        public string policyUnpaidPremiumAmount { get; set; }
        /// <summary>
        /// Policy Fee 1 Type (Valid Values: "T"=Taxes, "F"=Fees). Max length 1
        /// </summary>
        public string policyFee1Type { get; set; }
        /// <summary>
        /// Policy Fee 1 Description. Max length 30
        /// </summary>
        public string policyFee1Description { get; set; }
        /// <summary>
        /// Policy Fee 1 Amount. Max length 11
        /// </summary>
        public string policyFee1Amount { get; set; }
        /// <summary>
        /// Policy Fee 1 Down Payment. Max length 11
        /// </summary>
        public string policyFee1AmountDownpay { get; set; }
        /// <summary>
        /// Policy Fee 1 Unpaid Amount = Total Policy Fee - Total Down Payment. Max length 11
        /// </summary>
        public string policyFee1UnpaidAmount { get; set; }
        /// <summary>
        /// Policy Fee 2 Type (Valid Values: "T"=Taxes, "F"=Fees). Max length 1
        /// </summary>
        public string policyFee2Type { get; set; }
        /// <summary>
        /// Policy Fee 2 Description. Max length 30
        /// </summary>
        public string policyFee2Description { get; set; }
        /// <summary>
        /// Policy Fee 2 Amount. Max length 11
        /// </summary>
        public string policyFee2Amount { get; set; }
        /// <summary>
        /// Policy Fee 2 Down Payment. Max length 11
        /// </summary>
        public string policyFee2AmountDownpay { get; set; }
        /// <summary>
        /// Policy Fee 2 Unpaid Amount = Total Policy Fee - Total Down Payment. Max length 11
        /// </summary>
        public string policyFee2UnpaidAmount { get; set; }
        /// <summary>
        /// Policy Fee 3 Type (Valid Values: "T"=Taxes, "F"=Fees). Max length 1
        /// </summary>
        public string policyFee3Type { get; set; }
        /// <summary>
        /// Policy Fee 3 Description. Max length 30
        /// </summary>
        public string policyFee3Description { get; set; }
        /// <summary>
        /// Policy Fee 3 Amount. Max length 11
        /// </summary>
        public string policyFee3Amount { get; set; }
        /// <summary>
        /// Policy Fee 3 Down Payment. Max length 11
        /// </summary>
        public string policyFee3AmountDownpay { get; set; }
        /// <summary>
        /// Policy Fee 3 Unpaid Amount = Total Policy Fee - Total Down Payment. Max length 11
        /// </summary>
        public string policyFee3UnpaidAmount { get; set; }
        /// <summary>
        /// Policy Fee 4 Type (Valid Values: "T"=Taxes, "F"=Fees). Max length 1
        /// </summary>
        public string policyFee4Type { get; set; }
        /// <summary>
        /// Policy Fee 4 Description. Max length 30
        /// </summary>
        public string policyFee4Description { get; set; }
        /// <summary>
        /// Policy Fee 4 Amount. Max length 11
        /// </summary>
        public string policyFee4Amount { get; set; }
        /// <summary>
        /// Policy Fee 4 Down Payment. Max length 11
        /// </summary>
        public string policyFee4AmountDownpay { get; set; }
        /// <summary>
        /// Policy Fee 4 Unpaid Amount = Total Policy Fee - Total Down Payment. Max length 11
        /// </summary>
        public string policyFee4UnpaidAmount { get; set; }

    }
}
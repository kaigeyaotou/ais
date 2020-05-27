using System.ComponentModel.DataAnnotations;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Policy Information of the Insured for generate premium finance agreement. This is an array and the length of the array is set to 8
    /// </summary>
    public class AddPreminumFinance_policy
    {
        /// <summary>
        /// Policy number of the policy. Max length 30
        /// </summary>
        [Required]
        public string policyNumber { get; set; }
        /// <summary>
        /// Inception Date (Effective Date) of the policy(Format: MMDDYYYY). Max length 8
        /// </summary>
        [Required]
        public string policyInceptionDate { get; set; }
        /// <summary>
        /// The period of coverage provided by the policy in months (If 12 month policy policyTerm is 12). Max length 2
        /// </summary>
        [Required]
        public int policyTerm { get; set; }
        /// <summary>
        /// "policyInsuranceCompanyCrossReference" is the code used by the client to identify insurance company on their system. This need to be setup in the AIS system first. "policyInsuranceCompanyCrossReference" is required when the "policyInsuranceCompanyNumber" is not available. Max length 12
        /// </summary>
        public string policyInsuranceCompanyCrossReference { get; set; }
        /// <summary>
        /// "policyInsuranceCompanyNumber" is the code used to identify insurance company which is supplied by AIS. "policyInsuranceCompanyNumber" is required when the "policyInsuranceCompanyCrossReference" is not available. Max length 4
        /// </summary>
        public string policyInsuranceCompanyNumber { get; set; }
        /// <summary>
        /// "policyCoverageTypeCrossReference" is the policy coverage type used by the client to identify the type of policy on their system. This needs to be setup in the AIS system first. "policyCoverageTypeCrossReference" is required when the "policyCoverageTypeCode is not available. Max length 12
        /// </summary>
        public string policyCoverageTypeCrossReference { get; set; }
        /// <summary>
        /// "policyCoverageTypeCode" is the code used to identify the policy coverage type which is supplied by AIS. "policyCoverageTypeCode" is required when the "policyCoverageTypeCrossReference" is not available. Max length 2
        /// </summary>
        public string policyCoverageTypeCode { get; set; }
        /// <summary>
        /// Policy Premium Amount. Max length 11
        /// </summary>
        [Required]
        public string policyPremiumAmount { get; set; }
        /// <summary>
        /// Policy Premium Down Payment. Max length 11
        /// </summary>
        [Required]
        public string policyPremiumDownpay { get; set; }
        /// <summary>
        /// Policy Fee 1 Type (Valid Values: "T"=Taxes, "F"=Fees, "A" or Blank=Taxes or Fees). Max length 1
        /// </summary>
        public string policyFee1Type { get; set; }
        /// <summary>
        /// Policy Fee 1 Description. "policyFee1Description" is required if "policyFee1Amount" is given. Max length 30
        /// </summary>
        public string policyFee1Description { get; set; }
        /// <summary>
        /// Policy Fee 1 Amount. "policyFee1Amount" is required if "policyFee1Description" is given. Max length 11
        /// </summary>
        public string policyFee1Amount { get; set; }
        /// <summary>
        /// Policy Fee 1 Down Payment. Max length 11
        /// </summary>
        public string policyFee1AmountDownpay { get; set; }
        /// <summary>
        /// Policy Fee 2 Type (Valid Values: "T"=Taxes, "F"=Fees, "A" or Blank=Taxes or Fees). Max length 1
        /// </summary>
        public string policyFee2Type { get; set; }
        /// <summary>
        /// Policy Fee 2 Description. "policyFee2Description" is required if "policyFee2Amount" is given. Max length 30
        /// </summary>
        public string policyFee2Description { get; set; }
        /// <summary>
        /// Policy Fee 2 Amount. "policyFee2Amount" is required if "policyFee2Description" is given. Max length 11
        /// </summary>
        public string policyFee2Amount { get; set; }
        /// <summary>
        /// Policy Fee 2 Down Payment. Max length 11
        /// </summary>
        public string policyFee2AmountDownpay { get; set; }
        /// <summary>
        /// Policy Fee 3 Type (Valid Values: "T"=Taxes, "F"=Fees, "A" or Blank=Taxes or Fees). Max length 1
        /// </summary>
        public string policyFee3Type { get; set; }
        /// <summary>
        /// Policy Fee 3 Description. "policyFee3Description" is required if "policyFee3Amount" is given. Max length 30
        /// </summary>
        public string policyFee3Description { get; set; }
        /// <summary>
        /// Policy Fee 3 Amount. "policyFee3Amount" is required if "policyFee3Description" is given. Max length 11
        /// </summary>
        public string policyFee3Amount { get; set; }
        /// <summary>
        /// Policy Fee 3 Down Payment. Max length 11
        /// </summary>
        public string policyFee3AmountDownpay { get; set; }
        /// <summary>
        /// Policy Fee 4 Type (Valid Values: "T"=Taxes, "F"=Fees, "A" or Blank=Taxes or Fees). Max length 1
        /// </summary>
        public string policyFee4Type { get; set; }
        /// <summary>
        /// Policy Fee 4 Description. "policyFee4Description" is required if "policyFee4Amount" is given. Max length 30
        /// </summary>
        public string policyFee4Description { get; set; }
        /// <summary>
        /// Policy Fee 4 Amount. "policyFee4Amount" is required if "policyFee4Description" is given. Max length 11
        /// </summary>
        public string policyFee4Amount { get; set; }
        /// <summary>
        /// Policy Fee 4 Down Payment. Max length 11
        /// </summary>
        public string policyFee4AmountDownpay { get; set; }
        /// <summary>
        /// Does policy have a filing? (Extended policy cancellation period) (Valid Values: "Y"=Yes, "N"/Blank=No). Max length 1
        /// </summary>
        public string policyFilingFlag { get; set; }
        /// <summary>
        /// Number of days insurance company required to give notice to additional regulatory agencies.(Extended policy cancellation period (number of days)). "policyFilingDays" is required if "policyFilingFlag" is set to "Y"
        /// </summary>
        public string policyFilingDays { get; set; }

    }
}
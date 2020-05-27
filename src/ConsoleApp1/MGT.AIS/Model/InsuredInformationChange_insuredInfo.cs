using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Information of the Insured(Policyholder) currently setup with a billing account to update name or address
    /// </summary>
    public class InsuredInformationChange_insuredInfo
    {
        /// <summary>
        /// ID assigned to Insured using client's identifier from their system. Max length 12
        /// </summary>
        public string insuredId { get; set; }
        /// <summary>
        /// Billing account number assigned by AIS. Max length 8
        /// </summary>
        public string aisAccountNumber { get; set;  }
        /// <summary>
        /// Insured name change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string insuredNameChangeFlag { get; set; }
        /// <summary>
        /// Business name of the Insured if commercial lines insurance coverage. Last name of the Insured if personal lines insurance coverage. Max length 30
        /// </summary>
        [Required]
        public string insuredName1 { get; set; }
        /// <summary>
        /// Second business name of the Insured if commercial lines coverage. First name of the Insured if personal lines coverage. Max length 30
        /// </summary>
        public string insuredName2 { get; set; }
        /// <summary>
        /// Insured address change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string insuredAddressChangeFlag { get; set; }
        /// <summary>
        /// Street address of the Insured. Insured address is required if insuredAddressChangeFlag set to "Y". Max length 30
        /// </summary>
        public string insuredAddress1 { get; set; }
        /// <summary>
        /// Street address of the Insured continued (if required). Max length 30
        /// </summary>
        public string insuredAddress2 { get; set; }
        /// <summary>
        /// City of the Insured. Insured city is required if insuredAddressChangeFlag set to "Y". Max length 23
        /// </summary>
        public string insuredCity { get; set; }
        /// <summary>
        /// State of the Insured (2 digit state abbreviation). Insured state is required if insuredAddressChangeFlag set to "Y". Max length 2
        /// </summary>
        public string insuredState { get; set; }
        /// <summary>
        /// Zip code of the Insured (Only use 5 digit zip code). Insured zip code is required if insuredAddressChangeFlag set to "Y". Max length 5
        /// </summary>
        public string insuredZip { get; set; }
        /// <summary>
        /// Insured phone change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string insuredPhoneChangeFlag { get; set; }
        /// <summary>
        /// Phone number of the Insured including 3 digit area code. Max length 10
        /// </summary>
        public string insuredPhoneNumber { get; set; }
        /// <summary>
        /// Insured fax change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string insuredFaxChangeFlag { get; set; }
        /// <summary>
        /// Fax Number of the Insured including 3 digit area code.Max length 10
        /// </summary>
        public string insuredFaxNumber { get; set; }
        /// <summary>
        /// Insured email change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string insuredEmailChangeFlag { get; set; }
        /// <summary>
        /// E-Mail Address of the Insured to be used for all email notifications. Max length 50
        /// </summary>
        public string insuredEmail { get; set; }
        /// <summary>
        /// Insured mobile phone change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string insuredCellPhoneChangeFlag { get; set; }
        /// <summary>
        /// Mobile phone service provider code of the Insured which supplied by AIS(eg.AT&T, 6=Verizon) Required if "insuredCellPhoneNumber" is given.Max length 2
        /// </summary>
        public string insuredCellPhoneServiceProviderCode { get; set; }
        /// <summary>
        /// Mobile phone number of the Insured including 3 digit area code. Required if "insuredCellPhoneServiceProviderCode" is given. Max length 10
        /// </summary>
        public string insuredCellPhoneNumber { get; set; }
        /// <summary>
        /// Insured bill mail option change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string insuredBillMailOptionChangeFlag { get; set; }
        /// <summary>
        /// Billing statement delivery method to the Insured (Valid Values: "E"=Email (E-Bill sent to the Insured as a PDF document) or leave blank for regular mail(Bill will be sent to the insured by USPS)). Max length 1
        /// </summary>
        public string insuredBillMailOption { get; set; }
        /// <summary>
        /// Insured bill reminder option change flag (Valid Values: "Y"=Yes or "N"=No). Max length 1
        /// </summary>
        [Required]
        public string insuredBillReminderOptionChangeFlag { get; set; }
        /// <summary>
        /// Method of sending reminders to the Insured, whenever a billing statement is ready(Valid Values: "E"=Email, "S"=SMS). Max length 1
        /// </summary>
        public string insuredBillReminderOption { get; set; }
    }
}

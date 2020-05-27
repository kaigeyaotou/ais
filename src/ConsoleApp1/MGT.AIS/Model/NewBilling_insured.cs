using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Information of the Insured(Policyholder) to be setup with a premium finance loan account
    /// </summary>
    public class NewBilling_insured
    {
        /// <summary>
        /// ID assigned to Insured using client's identifier from their system. Max length 12
        /// </summary>
        public string insuredId { get; set; }
        /// <summary>
        /// CA Number(Carrier Identification Number) assigned by the California Department of Motor Vehicles for auto/trucker policies. Max length 6
        /// </summary>
        public string insuredCANumber { get; set; }
        /// <summary>
        /// MC Number(Motor Carrier Number)assigned by the California Department of Motor Vehicles for auto/trucker policies. Max length 6
        /// </summary>
        public string insuredMCNumber { get; set; }
        /// <summary>
        /// Billing account number to be assigned by AIS. Max length 8
        /// </summary>
        public string aisAccountNumber { get; set; }
        /// <summary>
        /// Business name of the Insured if commercial lines insurance coverage. Last name of the Insured if personal lines insurance coverage. Max length 30
        /// </summary>
        [Required]
        public string insuredName1 { get; set; }
        /// <summary>
        /// Second business name of the Insured if commercial lines coverage. First name of the Insured if personal lines coverage. Max length 30
        /// </summary>
        [Required]
        public string insuredName2 { get; set; }
        /// <summary>
        /// Street address of the Insured. Max length 30
        /// </summary>
        [Required]
        public string insuredAddress1 { get; set; }
        /// <summary>
        /// Street address of the Insured continued (if required). Max length 30
        /// </summary>
        public string insuredAddress2 { get; set; }
        /// <summary>
        /// City of the Insured. Max length 23
        /// </summary>
        [Required]
        public string insuredCity { get; set; }
        /// <summary>
        /// State of the Insured (2 digit state abbreviation). Max length 2
        /// </summary>
        [Required]
        public string insuredState { get; set; }
        /// <summary>
        /// Zip code of the Insured (Only use 5 digit zip code). Max length 5
        /// </summary>
        [Required]
        public string insuredZip { get; set; }
        /// <summary>
        /// Phone number of the Insured including 3 digit area code. Max length 10
        /// </summary>
        public string insuredPhoneNumber { get; set; }
        /// <summary>
        /// Fax number of the Insured including 3 digit area code. Max length 10
        /// </summary>
        public string insuredFaxNumber { get; set; }
        /// <summary>
        /// E-Mail Address of the Insured to be used for all email notifications. Max length 50
        /// </summary>
        public string insuredEmail { get; set; }
        /// <summary>
        /// Mobile Phone Service Provider assigned by AIS (eg. 1=AT&T, 6=Verizon,see AIS for available codes). Required if "insuredCellPhoneNumber" is given. Max length 1
        /// </summary>
        public string insuredCellPhoneServiceProviderCode { get; set; }
        /// <summary>
        /// Mobile phone number of the Insured including 3 digit area code. Required if "insuredCellPhoneServiceProviderCode" is given. Max length 10
        /// </summary>
        public string insuredCellPhoneNumber { get; set; }
        /// <summary>
        /// Billing statement delivery method to the Insured (Valid Values: "E"=Email (E-Bill sent to the Insured as a PDF document) or "M"/Blank for regular mail(Bill will be sent to the insured by USPS)). Max length 1
        /// </summary>
        public string insuredBillMailOption { get; set; }
        /// <summary>
        /// Method of sending reminders to the Insured whenever a billing statement is ready(Valid Values: "E"=Email, "S"=SMS, "Y"=Both, "N"=None, Blank=SMS/Email). Max length 1
        /// </summary>
        public string insuredBillReminderOption { get; set; }
        /// <summary>
        /// Bank account type of the Insured which will use to make their payment (Valid Values: "C"=Checking "S"=Savings). Required if "bankABANumber" and "bankAccountNumber" are given. Bank Account information will be used to setup AutoPay. Max length 1
        /// </summary>
        public string bankAccountType { get; set; }
        /// <summary>
        /// ABA/Routing number of the bank account which Insured will use to make their payment. System will validate the routing number.(Valid Values: 9 digits number used to identify specific financial institutions within the United States). Required if "bankAccountType" is given. Bank Account information will be used to setup AutoPay. Max length 9
        /// </summary>
        public string bankABANumber { get; set; }
        /// <summary>
        /// Bank Account number which Insured will use to make their payment. Required if "bankAccountType" is given. Bank Account information will be used to setup AutoPay. Max length 17
        /// </summary>
        public string bankAccountNumber { get; set; }
        /// <summary>
        /// If business account enter the Insured's Federal ID Number. If personal account enter the Insured's Social Security Number. Max length 9
        /// </summary>
        public string insuredSSNFederalId { get; set; }
    }
}

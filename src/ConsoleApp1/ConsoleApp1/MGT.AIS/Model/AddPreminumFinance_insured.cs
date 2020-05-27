using System.ComponentModel.DataAnnotations;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Information of the Insured(Policyholder) to generate premium finance agreement
    /// </summary>
    public class AddPreminumFinance_insured
    {
        /// <summary>
        /// ID assigned to Insured using client's identifier from their system. Max length 12
        /// </summary>
        public string insuredId { get; set; }
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
        /// E-Mail address of the Insured to be used for all email notifications. Max length 50
        /// </summary>
        public string insuredEmail { get; set; }

    }
}
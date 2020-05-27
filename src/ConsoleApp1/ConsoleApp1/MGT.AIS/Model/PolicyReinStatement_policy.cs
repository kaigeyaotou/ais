using System.ComponentModel.DataAnnotations;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Policy Information of the premium finance loan account. This is an array and the length of the array is set to 8. Can be reinstate cancelled policies in a premium finance loan account
    /// </summary>
    public class PolicyReinStatement_policy
    {
        /// <summary>
        /// Policy number of the policy where policy reinstatement request to be applied. Max length 30
        /// </summary>
        [Required]
        public string policyNumber { get; set; }
    }
}
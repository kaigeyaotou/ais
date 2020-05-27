using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    public class InsuredInformationChangeArg
    {
        /// <summary>
        /// Information of the Insured(Policyholder) currently setup with a billing account to update name or address
        /// </summary>
        public InsuredInformationChange_insuredInfo insuredInfo { get; set; }
    }
}

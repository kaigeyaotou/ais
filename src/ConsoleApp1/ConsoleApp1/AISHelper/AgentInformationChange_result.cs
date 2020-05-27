using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.AISHelper
{
    public class AgentInformationChange_result
    {
        public AgentInformationChange_resultEntity results { get; set; }
    }
    public class AgentInformationChange_resultEntity
    {
        public string responseReference { get; set; }
        public string processingStatus { get; set; }
        public string returnCode { get; set; }
        public string returnMessage { get; set; }
        public string processedDateTime { get; set; }
        public string processedDate { get; set; }
        public string processedTime { get; set; }
        public string premiumFinanceCompanyCode { get; set; }
        public string agentCodeCrossReference { get; set; }
        public string agentCode { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.AISHelper
{
    public class PolicyReinStatementArgs
    {
        public string insuredId { get; set; }
        public string aisAccountNumber { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public string agentCodeCrossReference { get; set; }
        public string agentCode { get; set; }
        public string reinstateDate { get; set; }
        public string reinstateType { get; set; }
        public string requestedBy { get; set; }
        public IEnumerable<PolicyReinStatement_policy> policies { get; set; }
    }
}

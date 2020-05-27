using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Information of the Agent who wrote the insurance policy being setup for a premium finance loan account
    /// </summary>
    public class NewBilling_agent
    {
        /// <summary>
        /// "agentCodeCrossReference" is the code used by the client to identify the agent on their system. This needs to be setup in the AIS system first. Max length 12
        /// </summary>
        public string agentCodeCrossReference { get; set; }
        /// <summary>
        /// "agentCode" is the code used to identify the agent and it is supplied by AIS. "agentCode" is required when the "agentCodeCrossReference" not available. Max length 6
        /// </summary>
        public string agentCode { get; set; }
        /// <summary>
        /// Name of the Agent. System will validate the Agent Name. Max length 30
        /// </summary>
        public string agentName { get; set; }
        /// <summary>
        /// Name of the General Agent. Max length 30
        /// </summary>
        public string generalAgentName { get; set; }
    }
}

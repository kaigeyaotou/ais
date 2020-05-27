namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// Information of the Agent who wrote the insurance policy to generate premium finance agreement
    /// </summary>
    public class AddPreminumFinance_agent
    {
        /// <summary>
        /// "agentCodeCrossReference" is the code used by the client to identify the agent on their system. This needs to be setup in the AIS system first. "agentCodeCrossReference" is required when the "agentCode" is not available. Max length 12
        /// </summary>
        public string agentCodeCrossReference { get; set; }
        /// <summary>
        /// "agentCode" is the code used to identify the agent and it is supplied by AIS. "agentCode" is required when the "agentCodeCrossReference" not available. Max length 6
        /// </summary>
        public string agentCode { get; set; }
        /// <summary>
        /// Name of the Agent. Max length 40
        /// </summary>
        public string agentName { get; set; }

    }
}
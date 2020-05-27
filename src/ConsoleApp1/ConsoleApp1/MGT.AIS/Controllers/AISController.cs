using MediatR;
using MGT.AIS.AISHelper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static MGT.AIS.Controllers.AdditionalPremiumEndorsement;
using static MGT.AIS.Controllers.AgentInformationChange;
using static MGT.AIS.Controllers.BillingAccountInformation;
using static MGT.AIS.Controllers.GenerateHttpClient;
using static MGT.AIS.Controllers.GeneratePremiumFinanceAgreement;
using static MGT.AIS.Controllers.GetAccess;
using static MGT.AIS.Controllers.InsuredInformationChange;
using static MGT.AIS.Controllers.NewBillingAccountSetup;
using static MGT.AIS.Controllers.PolicyCancellation;
using static MGT.AIS.Controllers.PolicyReinstatement;
using static MGT.AIS.Controllers.ReturnPremiumEndorsement;

namespace MGT.AIS.Controllers
{
    [Route("api/v1/ais")]
    public class AISController : ControllerBase
    {
        public AISController(IMediator mediator) : base(mediator)
        {
        }

        //[Route("access")]
        //[HttpPost]
        //[ProducesResponseType(typeof(string), 200)]
        //[SwaggerResponse(400, typeof(string), Description = "参数无效。")]
        //[SwaggerTag("AIS")]
        //public async Task<IdentityModel> Get()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://apidemo.epitomeais.com");
        //    GetAccessCommand accessCommand = new GetAccessCommand();
        //    accessCommand.httpClient = client;
        //    var result = await mediator.Send(accessCommand);

        //    return result;
        //}

        //[Route("httpclient")]
        //[HttpPost]
        //[ProducesResponseType(typeof(string), 200)]
        //[SwaggerResponse(400, typeof(string), Description = "参数无效。")]
        //[SwaggerTag("AIS")]
        //public async Task<HttpClient> GenerateHttpClient()
        //{
        //    GenerateHttpClientCommand generateHttpClientCommand = new GenerateHttpClientCommand();
        //    return await mediator.Send(generateHttpClientCommand);
        //}

        /// <summary>
        /// Used to setup a premium finance billing account for an insured on AIS system
        /// </summary>
        /// <param name="newBillingAccountSetupCommand"></param>
        /// <returns></returns>
        [Route("NewBillingAccountSetup")]
        [HttpPost]
        [ProducesResponseType(typeof(NewBilling_response), 200)]
        [SwaggerResponse(400, typeof(NewBilling_response), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<NewBilling_response> NewBillingAccountSetup([FromBody]NewBillingAccountSetupCommand newBillingAccountSetupCommand)
        {
            return await mediator.Send(newBillingAccountSetupCommand);
        }

        /// <summary>
        /// Used to increase the premium amount for a premium finance billing account currently setup on AIS system, due to an endorsement on an existing policy or a new policy.
        /// </summary>
        /// <param name="additionalPremiumEndorsementCommand"></param>
        /// <returns></returns>
        [Route("AdditionalPremiumEndorsement")]
        [HttpPost]
        [ProducesResponseType(typeof(AdditionalPreminum_result), 200)]
        [SwaggerResponse(400, typeof(AdditionalPreminum_result), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<AdditionalPreminum_result> AdditionalPremiumEndorsement([FromBody]AdditionalPremiumEndorsementCommand additionalPremiumEndorsementCommand)
        {
            return await mediator.Send(additionalPremiumEndorsementCommand);
        }

        /// <summary>
        /// Used to decrease the premium amount for a premium finance billing account currently setup on AIS system, due to an endorsement for a return premium or cancellation return premium.
        /// </summary>
        /// <param name="returnPremiumEndorsementCommand"></param>
        /// <returns></returns>
        [Route("ReturnPremiumEndorsement")]
        [HttpPost]
        [ProducesResponseType(typeof(ReturnPreminumEndorsement_result), 200)]
        [SwaggerResponse(400, typeof(ReturnPreminumEndorsement_result), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<ReturnPreminumEndorsement_result> ReturnPremiumEndorsement([FromBody]ReturnPremiumEndorsementCommand returnPremiumEndorsementCommand)
        {
            return await mediator.Send(returnPremiumEndorsementCommand);
        }

        /// <summary>
        /// Used to cancel a policy for a premium finance billing account currently setup on AIS system for any other reason other than non-payment of premium.
        /// </summary>
        /// <param name="policyCancellationCommand"></param>
        /// <returns></returns>
        [Route("PolicyCancellation")]
        [HttpPost]
        [ProducesResponseType(typeof(PolicyCancellation_result), 200)]
        [SwaggerResponse(400, typeof(PolicyCancellation_result), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<PolicyCancellation_result> PolicyCancellation([FromBody]PolicyCancellationCommand policyCancellationCommand)
        {
            return await mediator.Send(policyCancellationCommand);
        }

        /// <summary>
        /// Used to reinstate a policy for a premium finance billing account currently setup on AIS system that was previously cancelled for any reason other than non-payment of premium
        /// </summary>
        /// <param name="policyReinstatementCommand"></param>
        /// <returns></returns>
        [Route("PolicyReinstatement")]
        [HttpPost]
        [ProducesResponseType(typeof(PolicyReinStatement_result), 200)]
        [SwaggerResponse(400, typeof(PolicyReinStatement_result), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<PolicyReinStatement_result> PolicyReinstatement([FromBody]PolicyReinstatementCommand policyReinstatementCommand)
        {
            return await mediator.Send(policyReinstatementCommand);
        }

        /// <summary>
        /// Used to retrieve insured's billing account information (with or without policy details) for a premium finance billing account currently setup on AIS system.
        /// </summary>
        /// <param name="billingAccountInformationCommand"></param>
        /// <returns></returns>
        [Route("BillingAccountInformation")]
        [HttpPost]
        [ProducesResponseType(typeof(BillingAccountInformation_result), 200)]
        [SwaggerResponse(400, typeof(BillingAccountInformation_result), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<BillingAccountInformation_result> BillingAccountInformation([FromBody]BillingAccountInformationCommand billingAccountInformationCommand)
        {
            return await mediator.Send(billingAccountInformationCommand);
        }

        /// <summary>
        /// Used to change the insured’s address, phone, fax or email address for a premium finance billing account currently setup on AIS system.
        /// </summary>
        /// <param name="insuredInformationChangeCommand"></param>
        /// <returns></returns>
        [Route("InsuredInformationChange")]
        [HttpPost]
        [ProducesResponseType(typeof(InsuredInformationCHnage_result), 200)]
        [SwaggerResponse(400, typeof(InsuredInformationCHnage_result), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<InsuredInformationCHnage_result> InsuredInformationChange([FromBody]InsuredInformationChangeCommand insuredInformationChangeCommand)
        {
            return await mediator.Send(insuredInformationChangeCommand);
        }

        /// <summary>
        /// Used to change an agent’s name and address, phone, fax or email address for a premium finance billing account currently setup on AIS system.
        /// </summary>
        /// <param name="agentInformationChangeCommand"></param>
        /// <returns></returns>
        [Route("AgentInformationChange")]
        [HttpPost]
        [ProducesResponseType(typeof(AgentInformationChange_result), 200)]
        [SwaggerResponse(400, typeof(AgentInformationChange_result), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<AgentInformationChange_result> AgentInformationChange([FromBody]
        AgentInformationChangeCommand agentInformationChangeCommand)
        {
            return await mediator.Send(agentInformationChangeCommand);
        }

        /// <summary>
        /// Used to capture insured's premium finance billing account information and return a completed premium finance agreement.
        /// </summary>
        /// <param name="generatePremiumFinanceAgreementCommand"></param>
        /// <returns></returns>
        [Route("GeneratePremiumFinanceAgreement")]
        [HttpPost]
        [ProducesResponseType(typeof(AddPreminumFinanceResult), 200)]
        [SwaggerResponse(400, typeof(AddPreminumFinanceResult), Description = "参数无效。")]
        [SwaggerTag("AIS")]
        public async Task<AddPreminumFinanceResult> GeneratePremiumFinanceAgreement([FromBody]
        GeneratePremiumFinanceAgreementCommand generatePremiumFinanceAgreementCommand)
        {
            return await mediator.Send(generatePremiumFinanceAgreementCommand);
        }
    }
}

using AIS.MGT.Model.Models;
using AIS.MGT.QueryStack.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AIS.MGT.Api.Commands.AgencyQuery;
using static AIS.MGT.Api.Commands.ContractTreeQuery;
using static AIS.MGT.Api.Commands.ContractTypeQuery;
using static AIS.MGT.Api.Commands.CountriesQuery;
using static AIS.MGT.Api.Commands.CountryStateQuery;
using static AIS.MGT.Api.Commands.MPRelatedQuery;
using static AIS.MGT.Api.Commands.RateTableQuery;
using static AIS.MGT.Api.Commands.StateAdd;
using static AIS.MGT.Api.Commands.StateDropQuery;
using static AIS.MGT.Api.Commands.StateQuery;
using static AIS.MGT.Api.Commands.StatesQueryByCountryId;
using static AIS.MGT.Api.Commands.UnitLobCoverageDivisionTreeQuery;
using static AIS.MGT.Api.Commands.UnitTreeVersionQuery;
using static AIS.MGT.Api.Commands.UnitVersionQuery;
using static AIS.MGT.Api.Commands.VersionAdd;
using static AIS.MGT.Api.Commands.VersionsQuery;

namespace AIS.MGT.Api
{
    [Route("api/v1/preminum-finance")]
    public class PreminumFinanceController : Core.ControllerBase
    {
        public PreminumFinanceController(IMediator mediator) : base(mediator)
        {
        }
        /// <summary>
        /// get all states
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("states")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StateInfo>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<StateInfo>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<StateInfo>>> GetStateAll(StateQueryCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// add a new state
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("states")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<StateInfo>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<StateInfo>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<IActionResult> AddState([FromBody]StateAddCommand command)
        {
            var result = await mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// get state dropdown list
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("states-drop")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StateDrop>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<StateDrop>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<StateDrop>>> GetStateDrop(StateDropQueryCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// get agencies
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("agencies")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<StateDrop>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<StateDrop>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<(IEnumerable<IDictionary<string, object>> data, long count)>> GetAgencies([FromBody]AgencyQueryCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }


        /// <summary>
        /// get unit trees
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("unit-tree")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<UnitTreeOut>>> GetUnitTrees(UnitLobCoverageDivisionTreeQueryCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// get unit trees by versionid
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("unit-tree/version")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<UnitTreeOut>>> GetUnitTreesByVersionId(UnitTreeVersionQueryCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// get mp-related
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("mp-related")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<MPRelatedInfo>> GetMPRelated(MPRelatedQueryCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// get all versions
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("versions")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<UnitTreeOut>>> GetAllVersions(VersionsQueryCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// get all versions
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("versions")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<IActionResult> AddVersion([FromBody]VersionAddCommand command)
        {
            if (!command.versionArg.units.Any())
            {
                return BadRequest("please select unit ");
            }
            if (!command.versionArg.mpContracts.mp_contract_types.Any())
            {
                return BadRequest("please select contract-type ");
            }
            if (!command.versionArg.mpContracts.mp_payments.Any())
            {
                return BadRequest("please select payment ");
            }
            if (!command.versionArg.mpContracts.mp_sub_contracts.Any())
            {
                return BadRequest("please select sub-contract ");
            }
            if (command.versionArg.id_version == default(int))
            {
                return BadRequest("please select version");
            }


            return Ok();
        }

        [Route("unit-version")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<UnitVersion>>> GetUnitVersions(UnitVersionQueryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Route("contract-type")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<IDictionary<string, object>>>> GetContractType(ContractTypeQueryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Route("contract-tree")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<UnitVersion>>> GetContractTree(ContractTreeQueryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Route("country-state")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<country_states>>> GetCountryState(CountryStateQueryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Route("countries")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<country_states>>> GetAllCountries(CountriesQueryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        [Route("states/country/id")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<country_states>>> GetStatesByCountryId(StatesQueryByCountryIdCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Route("rate-tables")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitTreeOut>), 200)]
        [SwaggerResponse(400, typeof(IEnumerable<UnitTreeOut>), Description = "参数无效。")]
        [SwaggerTag("preminum-finance")]
        public async Task<ActionResult<IEnumerable<IDictionary<string, object>>>> GetRateTableAll(RateTableQueryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}

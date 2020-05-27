using AIS.MGT.Model.Models;
using AIS.MGT.QueryStack.IRepository;
using AIS.MGT.QueryStack.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.MGT.Api.Commands
{
    public class VersionAdd
    {
        public class VersionAddCommand : IRequest
        {
            public VersionArg versionArg { get; set; }
        }

        public class Handler : IRequestHandler<VersionAddCommand, Unit>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<Unit> Handle(VersionAddCommand request, CancellationToken cancellationToken)
            {
                // get max ord
                int maxOrd = await preminumFinanceRepository.GetVersionMaxOrder();
                maxOrd++;

                // add version return version_id
                VersionInfo versionInfo = new VersionInfo()
                {
                    eff_date = request.versionArg.eff_date,
                    ord = maxOrd
                };
                int version_id = await preminumFinanceRepository.AddVersion(versionInfo);

                // add sub-contract
                // add contract-type
                if (request.versionArg.mpContracts.mp_contract_types.Any())
                {
                    await preminumFinanceRepository.AddMPContractType(request.versionArg.mpContracts.mp_contract_types, version_id);

                    await preminumFinanceRepository.AddMPPayment(request.versionArg.mpContracts.mp_payments, version_id);

                    await preminumFinanceRepository.AddMPSubContract(request.versionArg.mpContracts.mp_sub_contracts, version_id);
                }

                // add agency
                var agencies_origin = (await preminumFinanceRepository.GetAgenciesByVersionId(request.versionArg.id_version)).Select(a => (IDictionary<string, object>)a);
                if (request.versionArg.agencies.Any())
                {
                    var adds = new List<agency_version_arg>();
                    foreach (var item in agencies_origin)
                    {
                        if (!request.versionArg.agencies.Any(a => a.haspf == Convert.ToBoolean(item["has_pf"]) && a.rate_id == Convert.ToInt32(item["rate_id"]) && a.agency_id == Convert.ToInt32(item["agency_id"])))
                        {
                            adds.Add(request.versionArg.agencies.FirstOrDefault(a => a.haspf == Convert.ToBoolean(item["has_pf"]) && a.rate_id == Convert.ToInt32(item["rate_id"]) && a.agency_id == Convert.ToInt32(item["agency_id"])));
                        }
                    }



                    var agency_ids = new List<Guid>();
                    foreach (var item in adds)
                    {
                        agency_ids.Add(Guid.NewGuid());
                    }
                    // add agencies
                    var param_agency = new List<pf_agency_info>();
                    for (int i = 0; i < adds.Count(); i++)
                    {
                        var item = adds.ToList()[i];
                        var param = new pf_agency_info()
                        {
                            agency_id = item.agency_id,
                            has_pf = item.haspf,
                            rate_id = item.rate_id,
                            id_agency = agency_ids[i]
                        };
                        param_agency.Add(param);
                    }
                    await preminumFinanceRepository.AddPFAgency(param_agency);

                    // add version_agency
                    await preminumFinanceRepository.AddPFVersionAgency(agency_ids, version_id);
                }
                else
                {
                    if (agencies_origin.Any())
                    {
                        var param_ids = new List<Guid>();
                        foreach (var item in agencies_origin)
                        {
                            param_ids.Add(new Guid(item["agency_id"].ToString()));
                        }
                        await preminumFinanceRepository.AddPFVersionAgency(param_ids, version_id);
                    }
                }
                // add unit
                if (request.versionArg.units.Any())
                {
                    if (request.versionArg.units.Any(a => a == 0))
                    {
                        List<UnitTreeInfo> param = new List<UnitTreeInfo>()
                        {
                           new UnitTreeInfo(){ id_division_product = 0 }
                        };
                        await preminumFinanceRepository.AddUnitTree(param, version_id);
                    }
                    else
                    {
                        var unitargs = from item in request.versionArg.units
                                       select new UnitTreeInfo()
                                       {
                                           id_division_product = item
                                       };
                        await preminumFinanceRepository.AddUnitTree(unitargs.ToList(), version_id);
                    }
                }
                // add states
                var states_add = request.versionArg.stateArgs.Where(a => !string.IsNullOrEmpty(a.status));
                var states_origin = request.versionArg.stateArgs.Where(a => string.IsNullOrEmpty(a.status));

                if (states_add.Any())
                {
                    var param_state_add = from item in states_add
                                          select new StateInfo()
                                          {
                                              effective_date = item.effective_date,
                                              expiration_date = item.expiration_date,
                                              hasexpiration = item.hasexpiration,
                                              id_state = item.id_state,
                                              license = item.license,
                                              state_id = item.state_id
                                          };
                    await preminumFinanceRepository.AddState(param_state_add.ToList(), version_id);
                }
                if (states_origin.Any())
                {
                    var param_state_add = from item in states_origin
                                          select new StateInfo()
                                          {
                                              effective_date = item.effective_date,
                                              expiration_date = item.expiration_date,
                                              hasexpiration = item.hasexpiration,
                                              id_state = item.id_state,
                                              license = item.license,
                                              state_id = item.state_id
                                          };
                    await preminumFinanceRepository.AddStateOrigin(param_state_add.ToList(), version_id);
                }

                return new Unit();

            }
        }
    }
}

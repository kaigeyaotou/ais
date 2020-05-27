using AIS.MGT.Model.Models;
using AIS.MGT.QueryStack.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AIS.MGT.Api.Commands
{
    public class ContractTreeQuery
    {
        public class ContractTreeQueryCommand : IRequest<IEnumerable<ContractTree>>
        {
            public int id_version { get; set; }
        }

        public class Handler : IRequestHandler<ContractTreeQueryCommand, IEnumerable<ContractTree>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<IEnumerable<ContractTree>> Handle(ContractTreeQueryCommand request, CancellationToken cancellationToken)
            {

                var selected = await preminumFinanceRepository.GetMPSubContract(request.id_version);

                var result = new List<ContractTree>();
                var contracts = await preminumFinanceRepository.GetContractTree();
                var contracts_format = contracts.Select(a => (IDictionary<string, object>)a);
                var bp_ids = from bp in contracts_format
                             group bp by bp["id_bp"] into g
                             select g;
                if (bp_ids.Any())
                {
                    foreach (var item in bp_ids)
                    {
                        var bp = contracts_format.FirstOrDefault(a => a["id_bp"] == item.Key);
                        ContractTree bp_entity = new ContractTree()
                        {
                            id = Convert.ToInt32(bp["id_bp"]) + 10000,
                            Data = new ContractData()
                            {
                                id_bp = Convert.ToInt32(bp["id_bp"]),
                                bp_name = bp["bp_name"].ToString(),
                                id = Convert.ToInt32(bp["id_bp"]) + 10000
                            },
                            State = new ContractTreeState(),
                            text = bp["bp_name"]?.ToString() ?? "",
                            Children = new List<ContractTree>()
                        };
                        var contract_contracts = contracts_format.Where(a => Convert.ToInt32(a["id_bp"]) == Convert.ToInt32(item.Key));
                        if (contract_contracts.Any())
                        {
                            var contract_ids = from contract in contract_contracts
                                               group contract by contract["id_contract"] into g
                                               select g;

                            if (contract_ids.Any())
                            {
                                foreach (var contract_id in contract_ids)
                                {
                                    var contract = contract_contracts.FirstOrDefault(a => a["id_contract"] == contract_id.Key);
                                    ContractTree contract_entity = new ContractTree()
                                    {
                                        id = Convert.ToInt32(contract["id_contract"]) + 100000,
                                        Data = new ContractData()
                                        {
                                            contract_name = contract["contract_name"]?.ToString() ?? "",
                                            id_contract = Convert.ToInt32(contract["id_contract"]),
                                            id = Convert.ToInt32(contract["id_contract"]) + 100000
                                        },
                                        text = contract["contract_name"]?.ToString() ?? "",
                                        State = new ContractTreeState(),
                                        Children = new List<ContractTree>()
                                    };

                                    var subcontracts = contract_contracts.Where(a => Convert.ToInt32(a["id_contract"]) == Convert.ToInt32(contract_id.Key));

                                    if (subcontracts.Any())
                                    {
                                        foreach (var subcontract in subcontracts)
                                        {
                                            ContractTree subcontract_entity = new ContractTree()
                                            {
                                                Data = new ContractData()
                                                {
                                                    subcontract_name = subcontract["subcontract_name"]?.ToString() ?? "empty",
                                                    id = Convert.ToInt32(subcontract["subcontract_id"])
                                                },
                                                id = Convert.ToInt32(subcontract["subcontract_id"]),
                                                State = new ContractTreeState(),
                                                text = subcontract["subcontract_name"]?.ToString() ?? "empty"
                                            };
                                            if (selected.Any(a => a == subcontract_entity.id))
                                            {
                                                subcontract_entity.State.Selected = true;
                                                contract_entity.State.Opened = true;
                                            }
                                            
                                            contract_entity.Children.Add(subcontract_entity);
                                        }
                                    }
                                    if (selected.Any(a => a == contract_entity.id))
                                    {
                                        contract_entity.State.Selected = true;
                                        bp_entity.State.Opened = true;
                                    }
                                    
                                    bp_entity.Children.Add(contract_entity);
                                }
                            }
                        }

                        result.Add(bp_entity);
                    }
                }


                return result;
            }
        }
    }
}

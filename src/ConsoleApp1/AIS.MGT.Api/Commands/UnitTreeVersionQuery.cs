using AIS.MGT.Model.Models;
using AIS.MGT.QueryStack.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.MGT.Api.Commands
{
    public class UnitTreeVersionQuery
    {
        public class UnitTreeVersionQueryCommand : IRequest<IEnumerable<UnitTreeOut>>
        {
            public int id_version { get; set; }
        }

        public class Handler : IRequestHandler<UnitTreeVersionQueryCommand, IEnumerable<UnitTreeOut>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }

            public async Task<IEnumerable<UnitTreeOut>> Handle(UnitTreeVersionQueryCommand request, CancellationToken cancellationToken)
            {
                var selected = await preminumFinanceRepository.GetVersionUnits(request.id_version);
                List<UnitTreeOut> result = new List<UnitTreeOut>();
                var data = (await preminumFinanceRepository.GetLobUnitsCoverageDivision()).ToList();
                if (data.Any())
                {
                    // group by product_id 
                    var product_ids = from product in data
                                      group product by product.id_product into g
                                      select g;

                    if (product_ids.Any())
                    {
                        foreach (var productId in product_ids)
                        {
                            var product = data.FirstOrDefault(a => a.id_product == productId.Key);
                            UnitTreeOut producttree = new UnitTreeOut()
                            {
                                id = product.id_division_product,
                                state = new State(),
                                Data = new Data()
                                {
                                    id_division_product = product.id_division_product,
                                    id_product = product.id_product,
                                },
                                Text = product.product_name
                            };
                            data.Remove(product);
                            var lob_data = data.Where(a => a.id_product == productId.Key).ToList();
                            var lob_ids = from lobitem in lob_data
                                          group lobitem by lobitem.id_lob into g
                                          select g;
                            if (lob_ids.Any())
                            {
                                List<UnitTreeOut> lobs = new List<UnitTreeOut>();
                                foreach (var lob_id in lob_ids)
                                {
                                    var lob = lob_data.FirstOrDefault(a => a.id_lob == lob_id.Key);
                                    lob_data.Remove(lob);
                                    UnitTreeOut lobtree = new UnitTreeOut()
                                    {
                                        id = lob.id_division_product,
                                        state = new State(),
                                        Data = new Data()
                                        {
                                            id_product = producttree.Data.id_product,
                                            id_lob = lob.id_lob,
                                            id_division_product = producttree.Data.id_division_product
                                        },
                                        Text = lob.lob_name
                                    };
                                    var division_data = lob_data.Where(a => a.id_lob == lob_id.Key).ToList();
                                    var division_ids = from divisionitem in division_data
                                                       group divisionitem by divisionitem.id_division into g
                                                       select g;
                                    if (division_ids.Any())
                                    {
                                        List<UnitTreeOut> divisions = new List<UnitTreeOut>();
                                        foreach (var division_id in division_ids)
                                        {
                                            var division = division_data.FirstOrDefault(a => a.id_division == division_id.Key);
                                            division_data.Remove(division);
                                            UnitTreeOut divisiontree = new UnitTreeOut()
                                            {
                                                id = division.id_division_product,
                                                state = new State(),
                                                Data = new Data()
                                                {
                                                    id_product = lobtree.Data.id_product,
                                                    id_division = division.id_division,
                                                    id_division_product = lobtree.Data.id_division_product,
                                                    id_lob = lobtree.Data.id_lob,
                                                },
                                                Text = division.division_name

                                            };

                                            var coverage_data = division_data.Where(a => a.id_division == division_id.Key);
                                            List<UnitTreeOut> coverages = new List<UnitTreeOut>();
                                            foreach (var coverageitem in coverage_data)
                                            {
                                                UnitTreeOut treecoverage = new UnitTreeOut()
                                                {
                                                    id = coverageitem.id_division_product,
                                                    state=new State() ,
                                                    Data = new Data()
                                                    {
                                                        id_division = divisiontree.Data.id_division,
                                                        id_coverage = coverageitem.id_coverage,
                                                        id_division_product = divisiontree.Data.id_division_product,
                                                        id_lob = divisiontree.Data.id_lob,
                                                        id_product = divisiontree.Data.id_product
                                                    },
                                                    Text = coverageitem.coverage_name
                                                };
                                                if (selected.Any(a => a.id_division_product == treecoverage.id))
                                                {
                                                    treecoverage.state.Selected = true;
                                                    treecoverage.state.Opened = true;
                                                }
                                                coverages.Add(treecoverage);
                                            }
                                            divisiontree.Children = coverages;
                                            if (coverages.Any(a => a.state.Selected))
                                            {
                                                divisiontree.state.Opened = true;
                                            }
                                            coverages = new List<UnitTreeOut>();
                                            if (selected.Any(a => a.id_division_product == divisiontree.id))
                                            {
                                                divisiontree.state.Selected = true;
                                            }
                                            divisions.Add(divisiontree);
                                        }
                                        if (divisions.Any(a => a.state.Selected))
                                        {
                                            lobtree.state.Opened = true;
                                        }
                                        lobtree.Children = divisions;
                                        divisions = new List<UnitTreeOut>();
                                    }
                                    if (selected.Any(a => a.id_division_product == lobtree.id))
                                    {
                                        lobtree.state.Selected = true;
                                    }
                                    lobs.Add(lobtree);
                                }
                                if (lobs.Any(a => a.state.Selected))
                                {
                                    producttree.state.Opened = true;
                                }
                                producttree.Children = lobs;
                                lobs = new List<UnitTreeOut>();
                            }
                            if (selected.Any(a => a.id_division_product == producttree.id))
                            {
                                producttree.state.Selected = true;
                            }
                            result.Add(producttree);
                        }
                    }
                }

                return result;
            }
        }
    }
}

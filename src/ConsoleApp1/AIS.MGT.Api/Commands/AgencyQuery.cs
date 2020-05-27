using AIS.MGT.QueryStack.IRepository;
using AIS.MGT.QueryStack.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.MGT.Api.Commands
{
    public class AgencyQuery
    {
        public class AgencyQueryCommand : IRequest<(IEnumerable<IDictionary<string, object>> data, int count)>
        {
            public IDictionary<string, object> condition { get; set; }
            public int pageIndex { get; set; }
            public int pageSize { get; set; }
        }
        public class Handler : IRequestHandler<AgencyQueryCommand, (IEnumerable<IDictionary<string, object>> data, int count)>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }



            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<(IEnumerable<IDictionary<string, object>> data, int count)> Handle(AgencyQueryCommand request, CancellationToken cancellationToken)
            {
                // 解析查询条件
                StringBuilder condition = new StringBuilder();
                if (request.condition.Any())
                {
                    // 解析查询条件

                    foreach (var item in request.condition)
                    {
                        // agency_name
                        if (item.Key == "condition_agency_name")
                        {
                            condition.Append(string.Format($@" AND AgencyName LIKE '%{item.Value}%'"));
                        }
                        // condition_state_id
                        if (item.Key == "condition_state_id")
                        {
                            condition.Append(string.Format($@" AND id_state = {item.Value}"));
                        }

                        // condition_zip
                        if (item.Key == "condition_zip")
                        {
                            condition.Append(string.Format($@" AND Zip LIKE '%{item.Value}%'"));
                        }

                        // condition_country_id
                        if (item.Key == "condition_country_id")
                        {
                            condition.Append(string.Format($@"	AND id_country = {item.Value}"));
                        }

                        // condition_ratetable_id
                        if (item.Key == "condition_ratetable_id")
                        {
                            condition.Append(string.Format($@"	AND id_ratetable = {item.Value}"));
                        }

                        // condition_pf
                        if (item.Key == "condition_pf")
                        {
                            condition.Append(string.Format($@"	AND has_pf = {item.Value}"));
                        }

                        //condition_address
                        if (item.Key == "condition_address")
                        {
                            condition.Append(string.Format($@" AND Address LIKE '%{item.Value}%'"));
                        }
                    }
                }
                //return await preminumFinanceRepository.GetAgencies();

                var result = await preminumFinanceRepository.GetAgencyPage(condition.ToString(), request.pageSize, request.pageIndex);
                var count = result.page;
                var data = result.data.Select(a => (IDictionary<string, object>)a);

                return (data, count);
            }
        }
    }
}

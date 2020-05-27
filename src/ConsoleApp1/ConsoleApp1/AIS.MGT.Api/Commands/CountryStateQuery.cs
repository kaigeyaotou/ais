using AIS.MGT.Core;
using AIS.MGT.QueryStack.IRepository;
using AIS.MGT.QueryStack.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.MGT.Api.Commands
{
    public class CountryStateQuery
    {
        public class CountryStateQueryCommand : IRequest<WebApiResult<IEnumerable<country_states>>> { }
        public class Handler : IRequestHandler<CountryStateQueryCommand, WebApiResult<IEnumerable<country_states>>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<WebApiResult<IEnumerable<country_states>>> Handle(CountryStateQueryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await preminumFinanceRepository.GetCountryStates();
                    return new WebApiResult<IEnumerable<country_states>>(result);
                }
                catch (Exception ex)
                {
                    return WebApiResult<IEnumerable<country_states>>.Error(ex.Message);
                }

            }
        }
    }
}

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
        public class CountryStateQueryCommand : IRequest<IEnumerable<country_states>> { }
        public class Handler : IRequestHandler<CountryStateQueryCommand, IEnumerable<country_states>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<IEnumerable<country_states>> Handle(CountryStateQueryCommand request, CancellationToken cancellationToken)
            {
                return await preminumFinanceRepository.GetCountryStates();
            }
        }
    }
}

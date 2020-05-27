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
    public class CountriesQuery
    {
        public class CountriesQueryCommand : IRequest<IEnumerable<countries>> { }

        public class Handler : IRequestHandler<CountriesQueryCommand, IEnumerable<countries>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<IEnumerable<countries>> Handle(CountriesQueryCommand request, CancellationToken cancellationToken)
            {
                return await preminumFinanceRepository.GetAllCountries();
            }
        }
    }
}

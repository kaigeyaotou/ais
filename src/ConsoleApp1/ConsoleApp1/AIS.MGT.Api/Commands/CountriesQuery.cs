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
    public class CountriesQuery
    {
        public class CountriesQueryCommand : IRequest<WebApiResult<IEnumerable<countries>>> { }

        public class Handler : IRequestHandler<CountriesQueryCommand, WebApiResult<IEnumerable<countries>>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<WebApiResult<IEnumerable<countries>>> Handle(CountriesQueryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await preminumFinanceRepository.GetAllCountries();
                    return new WebApiResult<IEnumerable<countries>>(result);
                }
                catch (Exception ex)
                {
                    return WebApiResult<IEnumerable<countries>>.Error(ex.Message);
                }

            }
        }
    }
}

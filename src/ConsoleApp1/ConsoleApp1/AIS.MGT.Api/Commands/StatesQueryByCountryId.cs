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
    public class StatesQueryByCountryId
    {
        public class StatesQueryByCountryIdCommand : IRequest<WebApiResult<IEnumerable<states>>>
        {
            public int id_country { get; set; }
        }
        public class Handler : IRequestHandler<StatesQueryByCountryIdCommand, WebApiResult<IEnumerable<states>>>
        {
            private IPreminumFinanceRepository preminumFinanceRepository;

            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            public async Task<WebApiResult<IEnumerable<states>>> Handle(StatesQueryByCountryIdCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await preminumFinanceRepository.GetStateByCountryId(request.id_country);

                    return new WebApiResult<IEnumerable<states>>(result);
                }
                catch (Exception ex)
                {
                    return WebApiResult<IEnumerable<states>>.Error(ex.Message);
                }

            }
        }
    }
}

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
    public class StateDropQuery
    {
        public class StateDropQueryCommand : IRequest<WebApiResult<IEnumerable<StateDrop>>>
        {

        }

        public class Handler : IRequestHandler<StateDropQueryCommand, WebApiResult<IEnumerable<StateDrop>>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<WebApiResult<IEnumerable<StateDrop>>> Handle(StateDropQueryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await preminumFinanceRepository.GetStateDrop();

                    return new WebApiResult<IEnumerable<StateDrop>>(result);
                }
                catch (Exception ex)
                {

                    return WebApiResult<IEnumerable<StateDrop>>.Error(ex.Message);
                }

            }
        }
    }
}

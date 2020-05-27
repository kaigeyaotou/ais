using AIS.MGT.Core;
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
    public class StateQuery
    {
        public class StateQueryCommand : IRequest<WebApiResult<IEnumerable<IDictionary<string, object>>>>
        {
            public int VersionId { get; set; }
        }
        public class Handler : IRequestHandler<StateQueryCommand, WebApiResult<IEnumerable<IDictionary<string, object>>>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<WebApiResult<IEnumerable<IDictionary<string, object>>>> Handle(StateQueryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = (await preminumFinanceRepository.GetStateByVersionId(request.VersionId)).Select(a => (IDictionary<string, object>)a);

                    return new WebApiResult<IEnumerable<IDictionary<string, object>>>(result);
                }
                catch (Exception ex)
                {
                    return WebApiResult<IEnumerable<IDictionary<string, object>>>.Error(ex.Message);
                }

            }
        }
    }
}

using AIS.MGT.Core;
using AIS.MGT.Model.Models;
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
    public class StateAdd
    {
        public class StateAddCommand : StateArgs, IRequest<WebApiResult<bool>> { }
        public class Handler : IRequestHandler<StateAddCommand, WebApiResult<bool>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<WebApiResult<bool>> Handle(StateAddCommand request, CancellationToken cancellationToken)
            {
                var result = false;
                try
                {
                    StateInfo stateInfo = new StateInfo()
                    {
                        effective_date = request.effective_date,
                        expiration_date = request.effective_date,
                        hasexpiration = request.hasexpiration,
                        license = request.license,
                        state_id = request.state_id
                    };
                    //await preminumFinanceRepository.AddState(stateInfo, 1   );
                    result = true;
                    return new WebApiResult<bool>(result);
                }
                catch (Exception ex)
                {
                    return WebApiResult<bool>.Error(ex.Message);
                }
            }
        }
    }
}

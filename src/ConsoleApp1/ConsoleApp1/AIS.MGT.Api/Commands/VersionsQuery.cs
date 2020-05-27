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
    public class VersionsQuery
    {
        public class VersionsQueryCommand : IRequest<WebApiResult<IEnumerable<VersionInfo>>> { }
        public class Handler : IRequestHandler<VersionsQueryCommand, WebApiResult<IEnumerable<VersionInfo>>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<WebApiResult<IEnumerable<VersionInfo>>> Handle(VersionsQueryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await preminumFinanceRepository.GetAllVersion();
                    return new WebApiResult<IEnumerable<VersionInfo>>(result);
                }
                catch (Exception ex)
                {
                    return WebApiResult<IEnumerable<VersionInfo>>.Error(ex.Message);
                }

            }
        }
    }
}

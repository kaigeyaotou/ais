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
        public class VersionsQueryCommand : IRequest<IEnumerable<VersionInfo>> { }
        public class Handler : IRequestHandler<VersionsQueryCommand, IEnumerable<VersionInfo>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<IEnumerable<VersionInfo>> Handle(VersionsQueryCommand request, CancellationToken cancellationToken)
            {
                return await preminumFinanceRepository.GetAllVersion();
            }
        }
    }
}

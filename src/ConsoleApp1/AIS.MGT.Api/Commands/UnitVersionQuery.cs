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
    public class UnitVersionQuery
    {
        public class UnitVersionQueryCommand : IRequest<IEnumerable<UnitVersion>>
        {
            public int id_version { get; set; }
        }
        public class Handler : IRequestHandler<UnitVersionQueryCommand, IEnumerable<UnitVersion>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<IEnumerable<UnitVersion>> Handle(UnitVersionQueryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await preminumFinanceRepository.GetVersionUnits(request.id_version);

                    return result;
                }
                catch (Exception ex)
                {

                    return null;
                }

            }
        }
    }
}

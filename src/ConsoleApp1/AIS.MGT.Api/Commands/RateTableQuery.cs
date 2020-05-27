using AIS.MGT.QueryStack.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.MGT.Api.Commands
{
    public class RateTableQuery
    {
        public class RateTableQueryCommand : IRequest<IEnumerable<IDictionary<string, object>>> { }

        public class Handler : IRequestHandler<RateTableQueryCommand, IEnumerable<IDictionary<string, object>>>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<IEnumerable<IDictionary<string, object>>> Handle(RateTableQueryCommand request, CancellationToken cancellationToken)
            {
                var rates = await preminumFinanceRepository.GetRateTableAll();
                var result = rates.Select(a => (IDictionary<string, object>)a);

                return result;
            }
        }
    }
}

using AIS.MGT.QueryStack.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.MGT.Api.Commands
{
    public class ContractTypeQuery
    {
        public class ContractTypeQueryCommand : IRequest<IEnumerable<IDictionary<string, object>>>
        {

        }

        public class Handler : IRequestHandler<ContractTypeQueryCommand, IEnumerable<IDictionary<string, object>>>
        {
            private IPreminumFinanceRepository preminumFinanceRepository;

            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            public async Task<IEnumerable<IDictionary<string, object>>> Handle(ContractTypeQueryCommand request, CancellationToken cancellationToken)
            {
                var contracts = (await preminumFinanceRepository.GetContractType()).Select(a => (IDictionary<string, object>)a);

                return contracts;
            }
        }
    }
}

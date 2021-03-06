﻿using AIS.MGT.Model.Models;
using AIS.MGT.QueryStack.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.MGT.Api.Commands
{
    public class MPRelatedQuery
    {
        public class MPRelatedQueryCommand : IRequest<MPRelatedInfo>
        {
            public int id_version { get; set; }
        }
        public class Handler : IRequestHandler<MPRelatedQueryCommand, MPRelatedInfo>
        {
            public Handler(IPreminumFinanceRepository preminumFinanceRepository)
            {
                this.preminumFinanceRepository = preminumFinanceRepository;
            }

            private IPreminumFinanceRepository preminumFinanceRepository { get; set; }
            public async Task<MPRelatedInfo> Handle(MPRelatedQueryCommand request, CancellationToken cancellationToken)
            {
                MPRelatedInfo relatedInfo = new MPRelatedInfo();

                var mp_contract_types = await preminumFinanceRepository.GetMPContractTypes(request.id_version);
                relatedInfo.mp_contract_types = mp_contract_types;

                var mp_payment = await preminumFinanceRepository.GetMPPayments(request.id_version);
                relatedInfo.mp_payments = mp_payment;

                var mp_subcontracts = await preminumFinanceRepository.GetMPSubContract(request.id_version);
                relatedInfo.mp_subcontracts = mp_subcontracts;

                return relatedInfo;
            }
        }
    }
}

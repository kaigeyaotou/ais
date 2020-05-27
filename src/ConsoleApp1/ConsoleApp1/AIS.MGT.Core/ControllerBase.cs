using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AIS.MGT.Core
{
    public class ControllerBase:Controller
    {
        public ControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected IMediator mediator { get; set; }
    }
}

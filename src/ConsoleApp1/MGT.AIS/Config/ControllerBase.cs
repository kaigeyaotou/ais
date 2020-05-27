using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGT.AIS
{
    public class ControllerBase : Controller
    {
        public ControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected IMediator mediator { get; set; }
    }
}

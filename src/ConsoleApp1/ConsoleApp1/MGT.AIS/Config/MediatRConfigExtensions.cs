using AIS.MGT.Api;
using MediatR;
using MGT.AIS.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGT.AIS
{
    public static class MediatRConfigExtensions
    {
        public static void ConfigureMediatR(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            // INFO: 这里注册更多的 MediatR's Handler
            services.AddMediatR(typeof(PreminumFinanceController).Assembly,
                typeof(AISController).Assembly);

        }
    }
}

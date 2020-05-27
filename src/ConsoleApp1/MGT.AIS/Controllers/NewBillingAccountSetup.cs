using MediatR;
using MGT.AIS.AISHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MGT.AIS.Controllers.GenerateHttpClient;

namespace MGT.AIS.Controllers
{
    public class NewBillingAccountSetup
    {
        public class NewBillingAccountSetupCommand : NewBillingArgs, IRequest<NewBilling_response>
        {
        }
        public class Handler : IRequestHandler<NewBillingAccountSetupCommand, NewBilling_response>
        {
            public Handler(IMediator mediator)
            {
                this.mediator = mediator;
            }

            private IMediator mediator { get; set; }
            public async Task<NewBilling_response> Handle(NewBillingAccountSetupCommand request, CancellationToken cancellationToken)
            {
                GenerateHttpClientCommand generateHttpClientCommand = new GenerateHttpClientCommand();
                var client = await mediator.Send(generateHttpClientCommand);
                string route = "/apidemo/1.0.0/services/premfin/account/new/setup";
                HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var ret = await client.PostAsync(route, httpContent);
                if (ret.IsSuccessStatusCode)
                {
                    var temp = await ret.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<NewBilling_response>(temp);
                    return result;
                }
                else
                {
                    var result = await ret.Content.ReadAsStringAsync();
                    return null;
                }
            }
        }
    }
}

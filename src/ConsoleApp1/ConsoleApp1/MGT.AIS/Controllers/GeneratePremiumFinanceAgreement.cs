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
    public class GeneratePremiumFinanceAgreement
    {
        public class GeneratePremiumFinanceAgreementCommand : AddPreminumFinanceArgs, IRequest<AddPreminumFinanceResult> { }

        public class Handler : IRequestHandler<GeneratePremiumFinanceAgreementCommand, AddPreminumFinanceResult>
        {
            public Handler(IMediator mediator)
            {
                this.mediator = mediator;
            }

            private IMediator mediator { get; set; }
            public async Task<AddPreminumFinanceResult> Handle(GeneratePremiumFinanceAgreementCommand request, CancellationToken cancellationToken)
            {
                GenerateHttpClientCommand generateHttpClientCommand = new GenerateHttpClientCommand();
                var client = await mediator.Send(generateHttpClientCommand);

                HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await client.PostAsync("/apidemo/1.0.0/services/premfin/quote/pfa/inquiry", httpContent);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<AddPreminumFinanceResult>(temp);
                    return result;
                }
                else
                {
                    var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                    return null;
                }
            }
        }
    }
}

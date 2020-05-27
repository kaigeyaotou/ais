using MediatR;
using MGT.AIS.AISHelper;
using MGT.AIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static MGT.AIS.Controllers.GetAccess;
using static MGT.AIS.Controllers.SessionTokenQuery;

namespace MGT.AIS.Controllers
{
    public class GenerateHttpClient
    {
        public class GenerateHttpClientCommand : IRequest<HttpClient> { }

        public class Handler : IRequestHandler<GenerateHttpClientCommand, HttpClient>
        {
            public Handler(HttpAddress httpAddress, IMediator mediator)
            {
                this.httpAddress = httpAddress;
                this.mediator = mediator;
            }

            private HttpAddress httpAddress { get; set; }
            private IMediator mediator { get; set; }
            public async Task<HttpClient> Handle(GenerateHttpClientCommand request, CancellationToken cancellationToken)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = httpAddress.Uri;

                // get access
                GetAccessCommand getAccessCommand = new GetAccessCommand() { httpClient = client };
                IdentityModel identity = await mediator.Send(getAccessCommand);
                client.DefaultRequestHeaders.Add("Authorization", string.Format($@"Bearer {identity.access_token}"));
                // get session
                LoginArgs loginArgs = new LoginArgs()
                {
                    password = httpAddress.password,
                    key = httpAddress.key,
                    userId = httpAddress.userId
                };
                SessionTokenQueryCommand sessionTokenQueryCommand = new SessionTokenQueryCommand()
                {
                    HttpClient = client,
                    loginArgs = loginArgs
                };
                var sessionToken = await mediator.Send(sessionTokenQueryCommand);

                client.DefaultRequestHeaders.Add("SessionToken", sessionToken.results);
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return await Task.FromResult(client);
            }
        }
    }
}

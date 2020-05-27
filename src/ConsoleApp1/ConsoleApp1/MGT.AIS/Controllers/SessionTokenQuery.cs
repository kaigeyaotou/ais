using MediatR;
using MGT.AIS.AISHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MGT.AIS.Controllers
{
    public class SessionTokenQuery
    {

        public class SessionTokenQueryCommand : IRequest<SessionToken>
        {
            public LoginArgs loginArgs { get; set; }
            public HttpClient HttpClient { get; set; }
        }

        public class Handler : IRequestHandler<SessionTokenQueryCommand, SessionToken>
        {
            public async Task<SessionToken> Handle(SessionTokenQueryCommand request, CancellationToken cancellationToken)
            {
                string encode = GetBase64Encoding(string.Format($"{request.loginArgs.key}:{request.loginArgs.password}"));

                GetSessionArgs getSessionArgs = new GetSessionArgs()
                {
                    password = encode,
                    userId = request.loginArgs.userId
                };

                HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(getSessionArgs), Encoding.UTF8, "application/json");


                HttpResponseMessage httpResponseMessage = await request.HttpClient.PostAsync("/apiauth/1.0.0/services/auth/login", httpContent);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var temp = await httpResponseMessage.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionToken>(temp);
                    return await Task.FromResult(result);
                }
                else { return null; }
            }

            private string GetBase64Encoding(string code)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(code);
                return System.Convert.ToBase64String(plainTextBytes);
            }
        }
    }
}

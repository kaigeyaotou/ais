using MediatR;
using MGT.AIS.AISHelper;
using MGT.AIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MGT.AIS.Controllers
{
    public class GetAccess
    {
        public class GetAccessCommand : IRequest<IdentityModel>
        {
            public HttpClient httpClient { get; set; }
        }

        public class Handler : IRequestHandler<GetAccessCommand, IdentityModel>
        {
            public Handler(HttpAddress httpAddress)
            {
                this.httpAddress = httpAddress;
            }

            private HttpAddress httpAddress { get; set; }
            public async Task<IdentityModel> Handle(GetAccessCommand request, CancellationToken cancellationToken)
            {
                request.httpClient.DefaultRequestHeaders.Add("Authorization", httpAddress.Authorization);


                var param = new List<KeyValuePair<string, string>>();
                param.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                try
                {
                    HttpResponseMessage ret = new HttpResponseMessage();
                    var httpContent = new FormUrlEncodedContent(param);
                    ret = await request.httpClient.PostAsync("token", httpContent);
                    if (ret.IsSuccessStatusCode)
                    {
                        var temp = await ret.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<IdentityModel>(temp);
                        request.httpClient.DefaultRequestHeaders.Remove("Authorization");
                        return result;

                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}

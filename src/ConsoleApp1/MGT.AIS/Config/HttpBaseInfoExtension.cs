using MGT.AIS.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGT.AIS.Config
{
    public static class HttpBaseInfoExtension
    {
        public static HttpAddress ConfigureHttpBase(this IConfiguration configuration)
        {
            HttpAddress httpAddress = new HttpAddress();
            httpAddress.Authorization = configuration.GetSection("HttpAddress:Authorization").Value;
            httpAddress.key = configuration.GetSection("HttpAddress:key").Value;
            httpAddress.password = configuration.GetSection("HttpAddress:password").Value;
            //httpAddress.Uri = new Uri(configuration.GetSection("HttpAddress:Uri").Value);
            httpAddress.Uri = new Uri("https://apidemo.epitomeais.com");
            httpAddress.userId = configuration.GetSection("HttpAddress:userId").Value;

            return httpAddress;
        }
    }
}

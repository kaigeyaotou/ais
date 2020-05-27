using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGT.AIS.Model
{
    public class HttpAddress
    {
        public Uri Uri { get; set; }
        public string password { get; set; }
        public string key { get; set; }
        public string userId { get; set; }
        public string Authorization { get; set; }
    }
}

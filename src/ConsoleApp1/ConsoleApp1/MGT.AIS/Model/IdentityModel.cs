using System;
using System.Collections.Generic;
using System.Text;

namespace MGT.AIS.AISHelper
{
    /// <summary>
    /// AIS Identity return Value
    /// </summary>
    public class IdentityModel
    {
        public string access_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
    }
}

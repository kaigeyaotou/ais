using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.QueryStack.Models
{
    public class VersionInfo
    {
        public int id_version { get; set; }
        public DateTime date_created { get; set; }
        public DateTime eff_date { get; set; }
        public int ord { get; set; }
    }
}

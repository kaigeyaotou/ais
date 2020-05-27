using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.QueryStack.Models
{
    public class pf_agency_info
    {
        public Guid id_agency { get; set; }
        public int agency_id { get; set; }
        public int rate_id { get; set; }
        public bool has_pf { get; set; }

    }
}

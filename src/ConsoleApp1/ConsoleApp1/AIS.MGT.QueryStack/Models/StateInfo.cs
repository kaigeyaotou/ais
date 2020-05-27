using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.QueryStack.Models
{
    public class StateInfo
    {
        public Guid id_state { get; set; }
        public int state_id { get; set; }
        public string license { get; set; }
        public DateTime effective_date { get; set; }
        public DateTime expiration_date { get; set; }
        public bool hasexpiration { get; set; }
    }
}

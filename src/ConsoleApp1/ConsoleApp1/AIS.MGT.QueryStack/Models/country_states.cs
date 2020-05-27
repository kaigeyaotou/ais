using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.QueryStack.Models
{
    public class country_states
    {
        public int id_state { get; set; }
        public string state_abbr { get; set; }
        public string state_name { get; set; }
        public int id_country { get; set; }
        public string country_abbr { get; set; }
        public string country_name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.QueryStack.Models
{
    public class StateDrop
    {
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Abbr { get; set; }
        public string StateName { get; set; }
    }
}

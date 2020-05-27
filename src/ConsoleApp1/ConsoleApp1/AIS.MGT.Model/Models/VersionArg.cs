using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.Model.Models
{
    public class VersionArg
    {
        public int id_version { get; set; }
        public DateTime eff_date { get; set; }
        public IEnumerable<int> units { get; set; }
        public IEnumerable<agency_version_arg> agencies { get; set; }
        public version_mp_contract_arg mpContracts { get; set; }
        public IEnumerable<StateArgs> stateArgs { get; set; }
    }
}

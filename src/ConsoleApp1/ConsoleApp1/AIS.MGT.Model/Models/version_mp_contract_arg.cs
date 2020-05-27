using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.Model.Models
{
    public class version_mp_contract_arg
    {
        public IEnumerable<int> mp_contract_types { get; set; }
        public IEnumerable<int> mp_sub_contracts { get; set; }
        public IEnumerable<int> mp_payments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.Model.Models
{
    public class MPRelatedInfo
    {
        public IEnumerable<int> mp_contract_types { get; set; }
        public IEnumerable<int> mp_subcontracts { get; set; }
        public IEnumerable<int> mp_payments { get; set; }
    }
}

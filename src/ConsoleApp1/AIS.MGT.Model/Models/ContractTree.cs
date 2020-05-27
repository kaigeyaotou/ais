using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.Model.Models
{
    public class ContractTree
    {
        public int id { get; set; }
        public string text { get; set; }
        public ContractTreeState State { get; set; }
        public ContractData Data { get; set; }
        public List<ContractTree> Children { get; set; }
    }

    public class ContractTreeState
    {
        public bool Opened { get; set; }
        public bool Selected { get; set; }
    }

    public class ContractData
    {
        public int id { get; set; }
        public int id_contract { get; set; }
        public string subcontract_name { get; set; }
        public string contract_name { get; set; }
        public string bp_name { get; set; }
        public int id_bp { get; set; }
    }
}

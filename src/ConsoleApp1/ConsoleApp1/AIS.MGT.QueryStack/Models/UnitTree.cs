using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.QueryStack.Models
{
    public class UnitTree
    {
        public int id_division_product { get; set; }
        public int id_division { get; set; }
        public int id_product { get; set; }
        public int id_lob { get; set; }
        public int id_coverage { get; set; }
        public string division_name { get; set; }
        public string product_name { get; set; }
        public string coverage_name { get; set; }
        public string lob_name { get; set; }
    }
}

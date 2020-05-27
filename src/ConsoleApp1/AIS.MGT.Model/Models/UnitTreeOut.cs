using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.Model.Models
{
    public class UnitTreeOut
    {
        public int id { get; set; }
        public string Text { get; set; }
        public Data Data { get; set; }
        public State state { get; set; }
        public IEnumerable<UnitTreeOut> Children
        { get; set; }
    }

    public class State
    {
        public bool Opened { get; set; }
        public bool Selected { get; set; }
    }
    public class Data
    {
        public int id_division_product { get; set; }
        public int id_division { get; set; }
        public int id_product { get; set; }
        public int id_lob { get; set; }
        public int id_coverage { get; set; }
    }
}

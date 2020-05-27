using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.QueryStack.Models
{
    public class AgencyInfo
    {
        public int id_agency { get; set; }
        public string name { get; set; }
        public int code_number { get; set; }
        public string city { get; set; }
        public int id_country { get; set; }
        public int id_state { get; set; }
        public string zip { get; set; }
        public string addr2 { get; set; }
        public int active { get; set; }
        public string addr1 { get; set; }
        public string phone_number { get; set; }
        public string fax_number { get; set; }
        public DateTime date_created { get; set; }
        public int from_web { get; set; }
        public int partner { get; set; }
        public int source { get; set; }
        public string refer { get; set; }
        public int master { get; set; }
        public DateTime date_modified { get; set; }
        public int edit_web { get; set; }
        public int agreement_status { get; set; }
        public int no_medal { get; set; }
        public DateTime date_approved { get; set; }
    }
}

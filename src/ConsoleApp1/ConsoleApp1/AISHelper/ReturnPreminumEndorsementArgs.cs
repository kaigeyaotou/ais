using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.AISHelper
{
    public class ReturnPreminumEndorsementArgs
    {
        public string insuredId { get; set; }
        public string insuredName1 { get; set; }
        public string aisAccountNumber { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public IEnumerable<ReturnPreminumEndorsement_policy> policies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.AISHelper
{
    public class AddPreminumFinanceArgs
    {
        public AddPreminumFinance_insured insured { get; set; }
        public AddPreminumFinance_agent agent { get; set; }
        public AddPreminumFinance_account account { get; set; }
        public IEnumerable<AddPreminumFinance_policy> policies   { get; set; }
    }
}

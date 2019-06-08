using System;
using Calculator.Core;
using System.Collections.Generic;

namespace Calculator.Core
{
    public class TaxBracket
    {
        public int Low { get; set; }
        public int High { get; set; }
        public decimal Rate { get; set; }
    }
}

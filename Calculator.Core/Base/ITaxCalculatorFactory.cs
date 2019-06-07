using System;
using Calculator.Core;
using System.Collections.Generic;

namespace Calculator.Core
{
    public interface ITaxCalculatorFactory
    {
        ITaxStrategy GetTaxStrategy(TaxStrategyType strategy);
    }
}

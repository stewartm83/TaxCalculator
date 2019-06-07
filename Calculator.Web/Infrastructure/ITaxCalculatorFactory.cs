using System;
using Calculator.Core;
using System.Collections.Generic;

namespace Calculator.Web.Infrastructure
{
    public interface ITaxCalculatorFactory
    {
        ITaxStrategy GetTaxStrategy(TaxStrategyType strategy);
    }
}
using System;
using Calculator.Core;
using System.Collections.Generic;

namespace Calculator.Web.Infrastructure
{
    public class TaxCalculatorFactory : ITaxCalculatorFactory
    {
        public Dictionary<string, TaxStrategyType> PostalCodeStrategyMap { get; set; }
        public ITaxStrategy GetTaxStrategy(TaxStrategyType strategy)
        {
            switch (strategy)
            {
                case TaxStrategyType.FLAT_VALUE:
                    return new FlatValueStrategy();
                    break;
                case TaxStrategyType.PROGRESSIVE:
                    return new ProgressiveStrategy();
                    break;
                case TaxStrategyType.FLAT_RATE:
                    return new FlatRateStrategy();
                    break;
                default:
                    return new FlatRateStrategy();
                    break;
            }      
        }
    }
}
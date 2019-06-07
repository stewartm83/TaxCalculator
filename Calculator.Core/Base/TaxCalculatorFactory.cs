using System;
using Calculator.Core;
using System.Collections.Generic;

namespace Calculator.Core
{
    public class TaxCalculatorFactory : ITaxCalculatorFactory
    {       
        public ITaxStrategy GetTaxStrategy(TaxStrategyType strategy)
        {
            switch (strategy)
            {
                case TaxStrategyType.FLAT_VALUE:
                    return new FlatValueStrategy();                 
                case TaxStrategyType.PROGRESSIVE:
                    return new ProgressiveStrategy();              
                case TaxStrategyType.FLAT_RATE:
                    return new FlatRateStrategy();             
                default:
                    return new FlatRateStrategy();           
            }      
        }
    }
}

using System;

namespace Calculator.Core
{
    public class FlatRateStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            return taxableIncome * 0.175M;
        }
    }
}

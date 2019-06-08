using System;

namespace Calculator.Core
{
    public class FlatRateStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            if (taxableIncome <= 0)
                return 0;

            return taxableIncome * 0.175M;
        }
    }
}

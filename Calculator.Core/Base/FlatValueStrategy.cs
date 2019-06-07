using System;

namespace Calculator.Core
{
    public class FlatValueStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            return taxableIncome < 171550 ? 0.05M * taxableIncome : 10000;
        }
    }
}

using System;

namespace Calculator.Core
{
    public class FlatValueStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount < 171550 ? 0.05M * amount : 10000;
        }
    }
}
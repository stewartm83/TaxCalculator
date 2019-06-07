using System;

namespace Calculator.Core
{
    public class ProgressiveStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal amount)
        {
            if (amount <= 8350)
            {
                return amount * 0.10M;
            }
            else if (amount > 8350 && amount <= 33950)
            {
                return amount * 0.15M;
            }
            else if (amount > 33950 && amount <= 82250)
            {
                return amount * 0.25M;
            }
            else if (amount > 82250 && amount <= 171550)
            {
                return amount * 0.28M;
            }
            else if (amount > 171550 && amount <= 372950)
            {
                return amount * 0.33M;
            }
            else
            {
                return amount * 0.35M;
            }
        }
    }
}
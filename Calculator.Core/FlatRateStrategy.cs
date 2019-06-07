using System;

namespace Calculator.Core {
    public class FlatRateStrategy : ITaxStrategy {
        public decimal CalculateTax (decimal amount) {
            return amount * 0.175M;
        }
    }
}
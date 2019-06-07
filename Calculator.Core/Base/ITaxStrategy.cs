using System;

namespace Calculator.Core {
    public interface ITaxStrategy {
        decimal CalculateTax (decimal amount);
    }
}

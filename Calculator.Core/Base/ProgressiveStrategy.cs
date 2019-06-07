using System;
using System.Linq;
using System.Collections.Generic;

namespace Calculator.Core
{
    public class ProgressiveStrategy : ITaxStrategy
    {
        private readonly List<TaxBracket> _taxBrackets;
        public ProgressiveStrategy()
        {
            // TODO: Move to config file and load on startup
            _taxBrackets = new List<TaxBracket>
            {
                new TaxBracket{
                    Low = 0,
                    High = 8350,
                    Rate = 0.10M
                },
                     new TaxBracket{
                    Low = 8351,
                    High = 33950,
                    Rate = 0.15M
                },
                     new TaxBracket{
                    Low = 33951,
                    High = 82250,
                    Rate = 0.25M
                },
                     new TaxBracket{
                    Low = 82251,
                    High = 171550,
                    Rate = 0.28M
                },
                     new TaxBracket{
                    Low = 171551,
                    High = 372950,
                    Rate = 0.33M
                },
                     new TaxBracket{
                    Low = 372950,
                    High = int.MaxValue,
                    Rate = 0.35M
                }
            };
        }
        public decimal CalculateTax(decimal taxableIncome)
        {
            var fullPayTax =
                 _taxBrackets.Where(t => t.High < taxableIncome)
                     .Select(t => t)
                     .ToArray()
                     .Sum(taxBracket => (taxBracket.High - taxBracket.Low) * taxBracket.Rate);

            var partialTax =
                _taxBrackets.Where(t => t.Low <= taxableIncome && t.High >= taxableIncome)
                    .Select(t => (taxableIncome - t.Low) * t.Rate)
                    .Single();


            return fullPayTax + partialTax;
        }
    }
}
using NUnit.Framework;
using Calculator.Core;

namespace Tests
{
    [TestFixture]
    public class FlatRateStrategyTests
    {
        private readonly ITaxStrategy flatRateStrategy;
        public FlatRateStrategyTests()
        {
            flatRateStrategy = new FlatRateStrategy();
        }

        [Test]
        public void BasicSalaryTest()
        {
            // Given
            var annualSalary = 10000;
            var expectedTax = 1750;

            // When 
            var actualTax = flatRateStrategy.CalculateTax(annualSalary);

            // Then
            Assert.IsTrue(actualTax > 0, "Actual calculated tax should be greater than zero");
            Assert.AreEqual(expectedTax, actualTax, "Expected tax is not equal to calculated tax");
        }

        [TestCase(-12000)]
        [TestCase(0)]
        public void InvalidSalaryTest(int annualSalary)
        {
            // When 
            var actualTax = flatRateStrategy.CalculateTax(annualSalary);

            // Then
            Assert.IsFalse(actualTax > 0, "Actual calculated tax should be greater than zero");
        }
    }
}
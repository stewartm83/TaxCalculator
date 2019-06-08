using NUnit.Framework;
using Calculator.Core;

namespace Tests
{
    [TestFixture]
    public class FlatValueStrategyTests
    {
        private readonly ITaxStrategy flatValueStrategy;
        public FlatValueStrategyTests()
        {
            flatValueStrategy = new FlatValueStrategy();
        }

        [Test]
        public void SalaryLessThanThresholdTest()
        {
            // Given
            var annualSalary = 10000;
            var expectedTax = 500;

            // When 
            var actualTax = flatValueStrategy.CalculateTax(annualSalary);

            // Then
            Assert.IsTrue(actualTax > 0, "Actual calculated tax should be greater than zero");
            Assert.AreEqual(expectedTax, actualTax, "Expected tax is not equal to calculated tax");
        }


        [TestCase(171551)]
        [TestCase(200000)]
        [TestCase(750000)]
        public void SalaryGreaterThanThresholdTest(int annualSalary)
        {
            // Given
            // var annualSalary = 200000;
            var expectedTax = 10000;

            // When 
            var actualTax = flatValueStrategy.CalculateTax(annualSalary);

            // Then
            Assert.IsTrue(actualTax > 0, "Actual calculated tax should be greater than zero");
            Assert.AreEqual(expectedTax, actualTax, "Expected tax is not equal to calculated tax");
        }

        [TestCase(-12000)]
        [TestCase(0)]
        public void InvalidSalaryTest(int annualSalary)
        {
            // Given      

            // When 
            var actualTax = flatValueStrategy.CalculateTax(annualSalary);

            // Then
            Assert.IsFalse(actualTax > 0, "Actual calculated tax should be greater than zero");
        }
    }
}
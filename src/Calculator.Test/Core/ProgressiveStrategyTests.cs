using NUnit.Framework;
using Calculator.Core;

namespace Tests
{
    [TestFixture]
    public class ProgressiveStrategyTests
    {
        private readonly ITaxStrategy progressiveStrategy;
        public ProgressiveStrategyTests()
        {
            progressiveStrategy = new ProgressiveStrategy();
        }

        [Test]
        public void BaseBracketTest()
        {
            // Given
            var annualSalary = 8350;
            var expectedTax = 835;

            // When 
            var actualTax = progressiveStrategy.CalculateTax(annualSalary);

            // Then
            Assert.IsTrue(actualTax > 0, "Actual calculated tax should be greater than zero");
            Assert.AreEqual(expectedTax, actualTax, "Expected tax is not equal to calculated tax");
        }

        [TestCase(32500)]
        [TestCase(28500)]
        [TestCase(10000)]
        public void SecondBracketTest(int annualSalary)
        {
            // Given         
            var expectedTax = (annualSalary - 8351) * 0.15M + 835;

            // When 
            var actualTax = progressiveStrategy.CalculateTax(annualSalary);

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
            var actualTax = progressiveStrategy.CalculateTax(annualSalary);

            // Then
            Assert.IsFalse(actualTax > 0, "Actual calculated tax should be greater than zero");
        }
    }
}
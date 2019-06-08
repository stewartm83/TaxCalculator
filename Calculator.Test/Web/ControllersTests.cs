using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Calculator.Core;
using Calculator.Web.Models;
using Calculator.Web.Controllers;

namespace Tests
{
    public class ControllersTests
    {
        CalculationsController calcController;
        public ControllersTests()
        {
            var serviceProvider = new ServiceCollection()
                     .AddLogging()
                     .AddDbContext<CalculatorContext>(options => options.UseSqlite("Data Source=Test.db"))
                     .AddScoped<ITaxCalculatorFactory, TaxCalculatorFactory>()
                     .BuildServiceProvider();

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<CalculationsController>();
            var context = serviceProvider.GetService<CalculatorContext>();

            var taxFactory = serviceProvider.GetService<ITaxCalculatorFactory>();

            calcController = new CalculationsController(taxFactory, context, logger);
        }

        [Test]
        public void NewCalculationTest()
        {
            var calculationVm = new Calculation { AnnualSalary = 10000, PostalCode = "1000" };
            var result = calcController.NewCalculation(calculationVm).Result;

            Assert.AreEqual(calculationVm.AnnualSalary, result.Result);
            Assert.AreEqual(calculationVm.PostalCode, result.Result);
        }

        [Test]
        public void GetCalculationTest()
        {
            // Given
            var calculationVm = new Calculation { AnnualSalary = 10000, PostalCode = "1000" };
            var expected = calcController.NewCalculation(calculationVm).Result;

            System.Console.WriteLine(expected.Value.Id);
            // When
            var actual = calcController.GetCalculation(expected.Value.Id).Result;

            // Then
            Assert.AreEqual(expected.Value.AnnualSalary, actual.Value.AnnualSalary);
            Assert.AreEqual(expected.Value.PostalCode, actual.Value.PostalCode);
            Assert.AreEqual(expected.Value.CreatedOn, actual.Value.CreatedOn);
            Assert.AreEqual(expected.Value.CalculatedTax, actual.Value.CalculatedTax);
        }

        [Test]
        public void GetCalculationsTest()
        {

            var result = calcController.Calculations().Result;
            Assert.IsTrue(result.Value.ToList().Count > 0);
        }


    }

}
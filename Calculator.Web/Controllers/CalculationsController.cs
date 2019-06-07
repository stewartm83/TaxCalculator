using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Calculator.Web.Infrastructure;
using Calculator.Web.Models;
using Calculator.Web.ViewModels;

namespace Calculator.Web.Controllers
{
    [Route("api/[controller]")]
    public class CalculationsController : Controller
    {
        private readonly ILogger<CalculationsController> _logger;
        private readonly ITaxCalculatorFactory _factory;
        private readonly CalculatorContext _context;

        // TODO: Move mapping to config file
        private Dictionary<string, TaxStrategyType> PostalCodeStrategyMap
        = new Dictionary<string, TaxStrategyType>(){
            {"7441", TaxStrategyType.PROGRESSIVE},
            {"A100", TaxStrategyType.FLAT_VALUE},
            {"7000", TaxStrategyType.FLAT_RATE},
            {"1000", TaxStrategyType.PROGRESSIVE}
        };
        public CalculationsController(
            ITaxCalculatorFactory factory,
            CalculatorContext context,
            ILogger<CalculationsController> logger)
        {
            _factory = factory;
            _context = context;
            _logger = logger;
        }

        [Route("[action]")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<IEnumerable<Calculation>>> Calculations()
        {
            var calculations = await _context.Calculations.ToListAsync();
            return Json(calculations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calculation>> GetGame(int id)
        {
            var calculation = await _context.Calculations.FindAsync(id);
            if (calculation == null)
            {
                _logger.LogInformation($"Calculation not found, id: {id}");
                return NotFound();
            }
            return new JsonResult(calculation);
        }

        [Route("calculate")]
        [HttpPost]
        public async Task<ActionResult<Calculation>> NewCalculation([FromBody]Calculation calculationVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid calculation model object from request");
                    return BadRequest("Invalid model object");
                }


                if (!PostalCodeStrategyMap.ContainsKey(calculationVm.PostalCode))
                {
                    _logger.LogError("No tax strategy configured for the given postal code");
                    return BadRequest("Invalid postal code");
                }

                var taxStrategyType = PostalCodeStrategyMap[calculationVm.PostalCode];
                var taxStrategy = _factory.GetTaxStrategy(taxStrategyType);
                var taxDue = taxStrategy.CalculateTax(calculationVm.AnnualSalary);

                var calculation = new Calculation
                {
                    PostalCode = calculationVm.PostalCode,
                    AnnualSalary = calculationVm.AnnualSalary,
                    CalculatedTax = taxDue,
                    CreatedOn = DateTime.Now
                };

                _context.Calculations.Add(calculation);
                await _context.SaveChangesAsync();

                return new JsonResult(calculation);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside NewCalculation action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Calculation>> DeleteCalculation(int id)
        {
            try
            {
                var calculation = await _context.Calculations.FindAsync(id);
                if (calculation == null)
                {
                    _logger.LogInformation($"Calculation not found, id: {id}");
                    return NotFound();
                }

                _context.Calculations.Remove(calculation);
                await _context.SaveChangesAsync();
                return new JsonResult(calculation);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCalculation action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
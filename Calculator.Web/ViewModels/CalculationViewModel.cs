using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Web.ViewModels
{
    public class CalculationViewModel
    {
        public string PostalCode { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}


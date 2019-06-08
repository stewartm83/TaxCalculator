using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Web.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualSalary { get; set; }

        public decimal CalculatedTax { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
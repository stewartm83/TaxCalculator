using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Web.Models
{
    public class CalculatorContext : DbContext
    {

        public DbSet<Calculation> Calculations { get; set; }

        public CalculatorContext(DbContextOptions<CalculatorContext> options)
          : base(options)
        { }
    }
}
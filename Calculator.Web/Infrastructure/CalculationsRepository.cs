using Calculator.Web.Models;

namespace Repository
{
    public class CalculationsRepository : RepositoryBase<Calculation>
    {
        public CalculationsRepository(CalculatorContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
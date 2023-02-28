using Kotano.DividendTaxCalculator.Services.Models;

namespace Kotano.DividendTaxCalculator.Services.Interfaces
{
    public interface ITaxCalculator
    {
        Task<CalculatorResult> Calculate(decimal desiredAmount, decimal taxRate);
    }
}

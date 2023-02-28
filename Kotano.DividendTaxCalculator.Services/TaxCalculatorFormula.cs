using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kotano.DividendTaxCalculator.Services.Interfaces;
using Kotano.DividendTaxCalculator.Services.Models;

namespace Kotano.DividendTaxCalculator.Services
{
    public class TaxCalculatorFormula : ITaxCalculator
    {
        public Task<CalculatorResult> Calculate(decimal desiredAmount, decimal taxRate)
        {
            // Error condition
            if (taxRate >= desiredAmount || desiredAmount < 2 || taxRate is < 1 or > 99)
            {
                return Task.FromResult(new CalculatorResult
                {
                    DesiredAmountNet = desiredAmount,
                    MinimumWithdrawalAmount = 0,
                    TaxAmount = 0,
                    TaxRate = taxRate
                });
            }

            var taxRateDecimal = taxRate / 100;
            var withdrawalAmount = Math.Ceiling(desiredAmount / (1 - taxRateDecimal));

            var result = new CalculatorResult
            {
                DesiredAmountNet = desiredAmount,
                MinimumWithdrawalAmount = withdrawalAmount,
                TaxAmount = withdrawalAmount * taxRate / 100,
                TaxRate = taxRate
            };

            return Task.FromResult(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using Kotano.DividendTaxCalculator.Services.Interfaces;
using Kotano.DividendTaxCalculator.Services.Models;

namespace Kotano.DividendTaxCalculator.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        public Task<CalculatorResult> Calculate(decimal desiredAmount, decimal taxRate)
        {
            // Error condition
            if (taxRate >= desiredAmount || desiredAmount is < 2 or > 1000000 || taxRate is < 1 or > 99)
            {
                return Task.FromResult(new CalculatorResult
                {
                    DesiredAmountNet = desiredAmount,
                    MinimumWithdrawalAmount = 0,
                    TaxAmount = 0,
                    TaxRate = taxRate
                });
            }

            var withdrawalAmount = desiredAmount;
            var workingTax = withdrawalAmount * taxRate / 100;

            // Iterate through amounts and do the calculation
            while (withdrawalAmount - workingTax < desiredAmount)
            {
                withdrawalAmount++;
                workingTax = Math.Ceiling((withdrawalAmount * taxRate) / 100);
            }

            var result = new CalculatorResult
            {
                DesiredAmountNet = desiredAmount,
                MinimumWithdrawalAmount = withdrawalAmount,
                TaxAmount = workingTax,
                TaxRate = taxRate
            };

            return Task.FromResult(result);
        }
    }
}

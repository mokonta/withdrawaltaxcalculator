namespace Kotano.DividendTaxCalculator.Services.Models
{
    public class CalculatorResult
    {
        public decimal MinimumWithdrawalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal DesiredAmountNet { get; set; }
    }
}

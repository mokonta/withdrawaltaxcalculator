using Kotano.DividendTaxCalculator.Services;
using Kotano.DividendTaxCalculator.Services.Interfaces;

namespace Kotano.DividendTaxCalculator.Tests
{
    [TestClass]
    public class TaxCalculatorFormula_Calculate
    {
        private readonly ITaxCalculator _taxCalculator;

        public TaxCalculatorFormula_Calculate()
        {
            _taxCalculator = new TaxCalculatorFormula();
        }

        [TestMethod]
        public async Task Calculate_InputIs100And10_Returns112()
        {
            var result = await _taxCalculator.Calculate(100, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(112, result.MinimumWithdrawalAmount);
        }

        [TestMethod]
        public async Task Calculate_InputIs100And30_Returns143()
        {
            var result = await _taxCalculator.Calculate(100, 30);

            Assert.IsNotNull(result);
            Assert.AreEqual(143, result.MinimumWithdrawalAmount);
        }

        [TestMethod]
        public async Task Calculate_InputIs150And20_Returns188()
        {
            var result = await _taxCalculator.Calculate(150, 20);

            Assert.IsNotNull(result);
            Assert.AreEqual(188, result.MinimumWithdrawalAmount);
        }

        [TestMethod]
        public async Task Calculate_InputIs50And15_Returns59()
        {
            var result = await _taxCalculator.Calculate(50, 15);

            Assert.IsNotNull(result);
            Assert.AreEqual(59, result.MinimumWithdrawalAmount);
        }

        [TestMethod]
        public async Task Calculate_InputIs1000And10_Returns1112()
        {
            var result = await _taxCalculator.Calculate(1000, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(1112, result.MinimumWithdrawalAmount);
        }
        
        [TestMethod]
        public async Task Calculate_InputIs10000And10_Returns11112()
        {
            var result = await _taxCalculator.Calculate(10000, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(11112, result.MinimumWithdrawalAmount);
        }

        [TestMethod]
        public async Task Calculate_InputIs100And100_ReturnsError()
        {
            var result = await _taxCalculator.Calculate(100, 100);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.MinimumWithdrawalAmount);
        }
        
        [TestMethod]
        public async Task Calculate_InputIs100And101_ReturnsError()
        {
            var result = await _taxCalculator.Calculate(100, 101);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.MinimumWithdrawalAmount);
        }
    }
}
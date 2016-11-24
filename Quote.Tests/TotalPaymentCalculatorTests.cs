using NUnit.Framework;

namespace Quote.Tests
{
    [TestFixture]
    public class TotalPaymentCalculatorTests
    {
        [Test]
        public void CalculateTotal()
        {
            int loanAmount = 1000;
            decimal interestRate = 0.07M;
            int months = 36;
            var monthlyPayment = 30.88M;
            var calculator = new TotalPaymentCalculator();
            var totalPayments = calculator.Calculate(monthlyPayment, loanAmount, interestRate, months);

            Assert.AreEqual(1111.53M, decimal.Round(totalPayments, 2));
        }
    }
}

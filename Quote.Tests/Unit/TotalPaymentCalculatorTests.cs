using NUnit.Framework;
using Quote.Calculators;

namespace Quote.Tests.Unit
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
            var calculator = new TotalRepaymentCalculator();
            var totalPayments = calculator.Calculate(monthlyPayment, loanAmount, interestRate, months);

            Assert.AreEqual(1111.53M, totalPayments);
        }
    }
}

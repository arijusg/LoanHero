using NUnit.Framework;
using Quote.Calculators;

namespace Quote.Tests.Unit
{
    [TestFixture]
    public class MonthlyPaymentCalculatorTests
    {
        [Test]
        public void Calculate()
        {
            var calculator = new MonthlyPaymentCalculator();
            int loanAmount = 1000;
            decimal interestRate = 0.0552M;
            int months = 36;

            var monthlyPayment = calculator.Calculate(loanAmount, interestRate, months);

            Assert.AreEqual(30.20M, monthlyPayment);
        }

        [Test]
        public void Calculate2()
        {
            var calculator = new MonthlyPaymentCalculator();
            int loanAmount = 1000;
            decimal interestRate = 0.07M;
            int months = 36;

            var monthlyPayment = calculator.Calculate(loanAmount, interestRate, months);

            Assert.AreEqual(30.88M, monthlyPayment);
        }

        [Test]
        public void Calculate3()
        {
            var calculator = new MonthlyPaymentCalculator();
            int loanAmount = 1000;
            decimal interestRate = 0.05M;
            int months = 12;

            var monthlyPayment = calculator.Calculate(loanAmount, interestRate, months);

            Assert.AreEqual(85.61M, monthlyPayment);
        }
    }
}

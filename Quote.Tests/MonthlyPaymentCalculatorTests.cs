using NUnit.Framework;

namespace Quote.Tests
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

            Assert.AreEqual(30.20, decimal.Round(monthlyPayment, 2)); //TODO Deal with leftover
        }

        [Test]
        public void Calculate2()
        {
            var calculator = new MonthlyPaymentCalculator();
            int loanAmount = 1000;
            decimal interestRate = 0.07M;
            int months = 36;

            var monthlyPayment = calculator.Calculate(loanAmount, interestRate, months);

            Assert.AreEqual(30.88M, decimal.Round(monthlyPayment, 2)); //TODO Deal with leftover
        }

        [Test]
        public void Calculate3()
        {
            var calculator = new MonthlyPaymentCalculator();
            int loanAmount = 1000;
            decimal interestRate = 0.05M;
            int months = 12;

            var monthlyPayment = calculator.Calculate(loanAmount, interestRate, months);

            Assert.AreEqual(85.61M, decimal.Round(monthlyPayment, 2)); //TODO Deal with leftover
        }


       
    }
}

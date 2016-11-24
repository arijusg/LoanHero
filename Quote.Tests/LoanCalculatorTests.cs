using System.Collections.Generic;
using NUnit.Framework;

namespace Quote.Tests
{
    public class LoanCalculatorTests
    {
        private List<Lender> _lenders;
        [SetUp]
        public void Init()
        {
            _lenders = new List<Lender>
            {
                new Lender("Bob", 0.075M, 640),
                new Lender("Jane", 0.069M, 480),
                new Lender("Fred", 0.071M, 520),
                new Lender("Mary", 0.104M, 170),
                new Lender("John", 0.081M, 320),
                new Lender("Dave", 0.074M, 140),
                new Lender("Angela", 0.071M, 60)
            };
        }

        [Test]
        public void LoanCalculator()
        {
            int amountToBorrow = 1000;
            var calculator = new LoanCalculator(_lenders);
            LoanQuote quote = calculator.Calculate(amountToBorrow);

            // var expectedQuote = new LoanQuote(1000, 0.07M, 30.78M, 1108.10M); //TODO Wrong example
            var expectedQuote = new LoanQuote(1000, 0.07M, 30.88M, 1111.53M);
            Assert.AreEqual(expectedQuote, quote);
        }

    }
}

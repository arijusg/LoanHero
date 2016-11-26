using System.Collections.Generic;
using NUnit.Framework;
using Quote.Calculators;
using Quote.Models;

namespace Quote.Tests.Unit
{
    [TestFixture]
    public class InterestRateCalculatorTests
    {
        [Test]
        public void CalculateInterest()
        {
            var loanLenders = new List<LoanLender>
            {
                new LoanLender(new Lender("Bob", 0.010M, 200), 200),
                new LoanLender(new Lender("Mike", 0.050M, 300), 300),
                new LoanLender(new Lender("Maze", 0.150M, 500), 500)
            };

            var calculator = new InterestRateCalculator();
            var rate = calculator.GetAverageInterestRate(loanLenders);

            Assert.AreEqual(0.092M, rate);
        }

        [Test]
        public void CalculateInterest2()
        {
            var loanLenders = new List<LoanLender>
            {
                new LoanLender(new Lender("Bob", 0.069M, 480), 200),
                new LoanLender(new Lender("Mike", 0.071M, 60), 300),
                new LoanLender(new Lender("Mike", 0.071M, 460), 300)
            };

            var calculator = new InterestRateCalculator();
            var rate = calculator.GetAverageInterestRate(loanLenders);

            Assert.AreEqual(0.070M, rate);
        }

        [Test]
        public void ThereAreNoLenders()
        {
            var calculator = new InterestRateCalculator();
            var rate = calculator.GetAverageInterestRate(new List<LoanLender>());

            Assert.AreEqual(0, rate);
        }

        [Test]
        public void LentAmountIsZero()
        {
            var loanLenders = new List<LoanLender>
            {
                new LoanLender(new Lender("Bob", 0.010M, 0), 0),
            };

            var calculator = new InterestRateCalculator();
            var rate = calculator.GetAverageInterestRate(new List<LoanLender>());

            Assert.AreEqual(0, rate);
        }

    }
}

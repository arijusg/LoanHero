using System;
using System.Collections.Generic;
using System.Linq;
using Quote.Models;

namespace Quote.Calculators
{
    public class InterestRateCalculator
    {
        public decimal GetAverageInterestRate(List<LoanLender> lenders)
        {
            if (lenders.Count == 0) return 0;

            decimal total = 0;

            foreach (LoanLender loanLender in lenders)
            {
                total += loanLender.AmountLent * loanLender.Lender.InterestRate;
            }

            var interest = total / lenders.Sum(x => x.AmountLent);

            return Math.Round(interest, 3);
        }
    }
}

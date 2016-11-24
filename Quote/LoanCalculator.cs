using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quote
{
    public class LoanCalculator
    {
        private readonly List<Lender> _lenders;

        public LoanCalculator(List<Lender> lenders)
        {
            _lenders = lenders;
        }

        public LoanQuote Calculate(int amountToBorrow)
        {
            int months = 36;
            var loanLenders = new List<LoanLender>();

            int amountLeft = amountToBorrow;

            var orderedLenders = _lenders.OrderBy(x => x.InterestRate);

            foreach (Lender lender in orderedLenders)
            {
                if (amountLeft > 0)
                {
                    if (amountLeft - lender.AvailableCash < 0)
                    {
                        loanLenders.Add(new LoanLender(lender, amountLeft));
                        break;
                    }

                    amountLeft -= lender.AvailableCash;
                    loanLenders.Add(new LoanLender(lender, lender.AvailableCash));
                }
            }
            
            var rateCalculator = new InterestRateCalculator();
            var amountLent = loanLenders.Sum(x => x.AmountLent);
            var interest = rateCalculator.GetAverageInterestRate(loanLenders);
            var paymentCaculator = new MonthlyPaymentCalculator();
            var monthlyRepayment = paymentCaculator.Calculate(amountLent, interest, months);
            //var aa  = new LoanQuote(1000, 7.0M, 30.78M, 1108.10M);
            var totalPaymentCalculator = new TotalPaymentCalculator();
            var totalRepayment = totalPaymentCalculator.Calculate(monthlyRepayment, amountLent, interest, months);
            var aa  = new LoanQuote(amountLent, interest, monthlyRepayment, totalRepayment);
            return aa;
        }

       


    }

    public class LoanLender
    {
        public LoanLender(Lender lender, int amountLent)
        {
            Lender = lender;
            AmountLent = amountLent;
        }

        public Lender Lender { get; private set; }
        public int AmountLent { get; private set; }
    }
}

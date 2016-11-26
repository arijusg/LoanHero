using System.Collections.Generic;
using System.Linq;
using Quote.Models;

namespace Quote.Calculators
{
    public class LoanCalculator
    {
        private readonly List<Lender> _lenders;

        public LoanCalculator(List<Lender> lenders)
        {
            _lenders = lenders;
        }

        public LoanQuote Calculate(int requestedAmountToBorrow, int months)
        {
            var selectedLoanLenders = SelectLendersForLoanAmount(requestedAmountToBorrow);
            var interestRate = GetCombinedInterestRateForTheLoan(selectedLoanLenders);
            var totalAmountLent = GetTotalAmountLent(selectedLoanLenders);
            var monthlyRepayment = GetMonthlyPayment(totalAmountLent, interestRate, months);
            var totalRepayment = GetTotalRepaymentValue(monthlyRepayment, totalAmountLent, interestRate, months);
            var quote = new LoanQuote(totalAmountLent, interestRate, monthlyRepayment, totalRepayment);
            return quote;
        }

        private List<LoanLender> SelectLendersForLoanAmount(int amountToBorrow)
        {
            var loanLenders = new List<LoanLender>();

            int amountLeft = amountToBorrow;
            
            foreach (Lender lender in GetOrderedLenders())
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
            return loanLenders;
        }

        private decimal GetCombinedInterestRateForTheLoan(List<LoanLender> loanLenders)
        {
            var rateCalculator = new InterestRateCalculator();
            return rateCalculator.GetAverageInterestRate(loanLenders);
        }

        private int GetTotalAmountLent(List<LoanLender> loanLenders)
        {
            return loanLenders.Sum(x => x.AmountLent);
        }

        private decimal GetTotalRepaymentValue(decimal monthlyPayment, int loanAmount, decimal interestRate, int months)
        {
            var totalPaymentCalculator = new TotalRepaymentCalculator();
            return totalPaymentCalculator.Calculate(monthlyPayment, loanAmount, interestRate, months);
        }

        private decimal GetMonthlyPayment(int loanAmount, decimal interestRate, int months)
        {
            var paymentCaculator = new MonthlyPaymentCalculator();
            return paymentCaculator.Calculate(loanAmount, interestRate, months);
        }

        private List<Lender> GetOrderedLenders()
        {
            return _lenders.OrderBy(x => x.InterestRate).ToList();
        }
    }
}

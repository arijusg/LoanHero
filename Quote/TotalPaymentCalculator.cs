using System;

namespace Quote
{
    public class TotalPaymentCalculator
    {
        public decimal Calculate(decimal monthlyPayment, int loanAmount, decimal interestRate, int months)
        {
            var monthlyInterestRate = interestRate / 12;
            var currentAmount = (decimal)loanAmount;
            var totalPaid = 0M;

            for (int i = 0; i < months; i++)
            {
                //Add interest
                var interest = Math.Round(currentAmount * (monthlyInterestRate), 2);
                currentAmount += interest;

                if (currentAmount < monthlyPayment)
                {
                    totalPaid += currentAmount;
                    break;
                }

                //Make payment
                currentAmount -= monthlyPayment;
                totalPaid += monthlyPayment;
            }

            return totalPaid;
        }
    }
}

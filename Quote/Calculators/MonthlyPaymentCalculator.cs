using System;

namespace Quote.Calculators
{
    public class MonthlyPaymentCalculator
    {
        public decimal Calculate(int loanAmount, decimal interestRate, int months)
        {
            //For repaying a loan of £1000 at 5 % interest for 12 months, the equation would be:
            //Monthly payment = [(0.05 / 12) + (0.05 / 12) / ((1 + (0.05 / 12)) ^ 12 - 1)] x principal loan amount

            var monthlyInterest = (double)interestRate / 12;
            var payment = ((monthlyInterest) + ((monthlyInterest) / (Math.Pow(1 + monthlyInterest, months) - 1))) * loanAmount;
            return Math.Round((decimal)payment, 2);
        }
    }
}

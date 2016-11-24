using System;

namespace Quote
{
    public class MonthlyPaymentCalculator
    {
        public decimal Calculate1(int loanAmount, decimal interestRate, int months)
        {
            interestRate = interestRate / 12;
            var repayment = (interestRate * loanAmount) / (decimal)(1 - Math.Pow(1 + (double)interestRate, (-1 * months)));
            return Math.Round(repayment, 2);
        }

        public decimal Calculate(int loanAmount, decimal interestRate, int months)
        {
            //            For repaying a loan of $1000 at 5 % interest for 12 months, the equation would be:
            //Monthly payment = [(0.05 / 12) + (0.05 / 12) / ((1 + (0.05 / 12)) ^ 12 - 1)] x principal loan amount

            /*
            For repaying a loan of $1000 at 5 % interest for 12 months, the equation would be:
    Monthly payment = [(0.05 / 12) + (0.05 / 12) / ((1 + (0.05 / 12)) ^ 12 - 1)] x principal loan amount
    Monthly payment = [0.0041666667 + 0.0041666667 / (1.0041666667 ^ 12 - 1)] x 1000.
    Monthly payment = [0.0041666667 + 0.0041666667 / (1.0511618983 - 1)] x 1000.
    Monthly payment = [0.0041666667 + 0.0041666667 / 0.0511618983] x 1000.
    Monthly payment = [0.0041666667 + 0.081440816] x 1000.
    Monthly payment = 0.085607483 x 1000.
    Monthly payment = 85.607483.
    */


            //Using formula:
            //Monthly payment = [ r + r / ( (1+r) ^ months -1) ] x principal loan amount
            //Where: r = decimal rate / 12.

            var monthlyInterest = (double)interestRate / 12;
            var payment = ((monthlyInterest) + ((monthlyInterest) / (Math.Pow(1 + monthlyInterest, months) - 1))) * loanAmount;
            return Math.Round((decimal)payment, 2);
        }
    }
}

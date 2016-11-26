using System;
using System.Collections.Generic;
using Quote.Calculators;
using Quote.Models;
using Quote.Output;

namespace Quote
{
    public class RateCalculator
    {
        public static void Main(string[] args)
        {
            try
            {
                //TODO validate
                string lenderCsvPath = args[1];
                int amountToBorrow = Convert.ToInt32(args[0]);

                if (!IsAmountValid(amountToBorrow)) return;

                int defaultLoanTermInMonths = 36;

                var quote = GenerateQuote(amountToBorrow, defaultLoanTermInMonths, lenderCsvPath);

                if (IsQuoteValid(amountToBorrow, quote))
                {
                    PrintQuote(quote);
                }
                else
                {
                    Console.WriteLine("It is not possible to provide a quote at this time");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Application error :(");
            }
            Console.ReadLine();
        }

        private static bool IsAmountValid(int loanAmount)
        {
            if (loanAmount < 100)
            {
                Console.WriteLine("The minimum amount you can borrow is £1000");
                return false;
            }
            if (loanAmount > 15000)
            {
                Console.WriteLine("The maximum amount you can borrow is £15000");
                return false;
            }
            if (loanAmount % 100 > 0)
            {
                Console.WriteLine("The amount you wish to borrow should be in increments of £100");
                return false;
            }
            return true;
        }

        private static LoanQuote GenerateQuote(int amountToBorrow, int months, string marketPath)
        {
            var lenders = GetLenders(marketPath);

            return GetQuote(amountToBorrow, months, lenders);
        }

        private static List<Lender> GetLenders(string lenderListPath)
        {
            var lendersLoader = new LenderDataReader();
            return lendersLoader.Read(lenderListPath);
        }

        private static LoanQuote GetQuote(int amountToBorrow, int months, List<Lender> lenders)
        {
            var quote = new LoanCalculator(lenders);
            return quote.Calculate(amountToBorrow, months);
        }

        private static bool IsQuoteValid(int loanAmount, LoanQuote quote)
        {
            if (loanAmount != quote.RequestedAmount)
            {

                return false;
            }
            return true;
        }

        private static void PrintQuote(LoanQuote quote)
        {
            var outputGenerator = new OutputGenerator();
            string output = outputGenerator.Generate(quote);
            Console.WriteLine(output);
        }
    }

}

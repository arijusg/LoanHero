using System;
using System.Collections.Generic;

namespace Quote
{
    public class RateCalculator
    {
        public static void Main(string[] args)
        {
            try
            {
                //TODO validate
                string marketPath = args[1];
                int amountToBorrow = Convert.ToInt32(args[0]);

               // GenerateQuote(amountToBorrow, marketPath);
                var generator = ComposeGenerator();
                generator.GenerateQuote(amountToBorrow, marketPath);

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Application error :(");
            }
        }

        private static QuoteGenerator ComposeGenerator()
        {
            Action<string> printText = Console.WriteLine;

            return new QuoteGenerator(printText);
        }

        //private static void GenerateQuote(int amountToBorrow, string marketPath)
        //{
        //    if (!IsAmountValid(amountToBorrow)) return;

        //    var lenders = GetLenders(marketPath);

        //    var quote = new LoanCalculator(lenders);
        //    var loanQuote = quote.Calculate(amountToBorrow);

        //    if (IsQuoteValid(amountToBorrow, loanQuote))
        //    {
        //        PrintQuote(loanQuote);
        //    }
        //}

        //private static void PrintQuote(LoanQuote quote)
        //{
        //    var outputGenerator = new OutputGenerator();
        //    string output = outputGenerator.Generate(quote);
        //    Console.WriteLine(output);
        //}

        //private static List<Lender> GetLenders(string lenderListPath)
        //{
        //    var lendersLoader = new LenderDataReader();
        //    return lendersLoader.Read(lenderListPath);
        //}

        //private static bool IsAmountValid(int loanAmount)
        //{
        //    if (loanAmount < 100)
        //    {
        //        Console.WriteLine("The minimum amount you can borrow is £1000");
        //        return false;
        //    }
        //    if (loanAmount > 15000)
        //    {
        //        Console.WriteLine("The maximum amount you can borrow is £15000");
        //        return false;
        //    }
        //    if (loanAmount % 100 > 0)
        //    {
        //        Console.WriteLine("The amount you wish to borrow should be in increments of £100");
        //        return false;
        //    }
        //    return true;
        //}

        //private static bool IsQuoteValid(int loanAmount, LoanQuote quote)
        //{
        //    if (loanAmount != quote.RequestedAmount)
        //    {
        //        Console.WriteLine("It is not possible to provide a quote at this time");
        //        return false;
        //    }
        //    return true;
        //}
    }

}

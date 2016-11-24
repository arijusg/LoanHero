using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quote
{
    public class QuoteGenerator
    {
        private Action<string> _printText;
        public QuoteGenerator(Action<string> printText)
        {
            _printText = printText;
        }

        public void GenerateQuote(int amountToBorrow, string marketPath)
        {
            if (!IsAmountValid(amountToBorrow)) return;

            var lenders = GetLenders(marketPath);

            var quote = new LoanCalculator(lenders);
            var loanQuote = quote.Calculate(amountToBorrow);

            if (IsQuoteValid(amountToBorrow, loanQuote))
            {
                PrintQuote(loanQuote);
            }
        }

        private void PrintQuote(LoanQuote quote)
        {
            var outputGenerator = new OutputGenerator();
            string output = outputGenerator.Generate(quote);
            Console.WriteLine(output);
        }

        private List<Lender> GetLenders(string lenderListPath)
        {
            var lendersLoader = new LenderDataReader();
            return lendersLoader.Read(lenderListPath);
        }

        private bool IsAmountValid(int loanAmount)
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

        private bool IsQuoteValid(int loanAmount, LoanQuote quote)
        {
            if (loanAmount != quote.RequestedAmount)
            {
                Console.WriteLine("It is not possible to provide a quote at this time");
                return false;
            }
            return true;
        }

    }
}

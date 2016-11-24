using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quote
{
    public class RateCalculator
    {
        public static void Main(string[] args)
        {
            //TODO validate

            string marketPath = args[1];
            int amountToBorrow = Convert.ToInt32(args[0]);
           var lendersLoader = new LenderDataReader();
            var lenders = lendersLoader.Read(marketPath);

            var quote = new LoanCalculator(lenders);
            var loacQuote = quote.Calculate(amountToBorrow);

            var outputGenerator = new OutputGenerator();
            //var q = new LoanQuote(1000, 7.0M, 30.78M, 1108.10M);
            string output = outputGenerator.Generate(loacQuote);
            Console.WriteLine(output);

            Console.ReadLine();
        }
    }

}

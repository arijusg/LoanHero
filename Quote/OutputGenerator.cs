using System.Text;

namespace Quote
{
    public class OutputGenerator
    {
        public string Generate(LoanQuote quote)
        {
            var outputBuilder = new StringBuilder();
            outputBuilder.Append($"Requested amount: £{quote.RequestedAmount}");
            outputBuilder.AppendLine();
            outputBuilder.Append($"Rate: {decimal.Round(quote.InterestRate * 100, 1)}%");
            outputBuilder.AppendLine();
            outputBuilder.Append($"Monthly repayment: £{decimal.Round(quote.MonthlyRepayment, 2)}");
            outputBuilder.AppendLine();
            outputBuilder.Append($"Total repayment: £{decimal.Round(quote.TotalRepayment, 2)}");
            return outputBuilder.ToString();
        }
    }
}

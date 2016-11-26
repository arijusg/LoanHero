namespace Quote.Models
{
    public class LoanQuote
    {
        public LoanQuote(int requestedAmount, decimal interestRate, decimal monthlyRepayment, decimal totalRepayment)
        {
            RequestedAmount = requestedAmount;
            InterestRate = interestRate;
            MonthlyRepayment = monthlyRepayment;
            TotalRepayment = totalRepayment;
        }

        public int RequestedAmount { get; }
        public decimal InterestRate { get; }
        public decimal MonthlyRepayment { get; }
        public decimal TotalRepayment { get; }

        public override string ToString()
        {
            return
                $"RequestedAmount: {RequestedAmount} InterestRate: {InterestRate} MonthlyRepayment: {MonthlyRepayment} TotalRepayment {TotalRepayment}";
        }


        protected bool Equals(LoanQuote other)
        {
            return RequestedAmount == other.RequestedAmount && InterestRate == other.InterestRate && MonthlyRepayment == other.MonthlyRepayment && TotalRepayment == other.TotalRepayment;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LoanQuote) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = RequestedAmount;
                hashCode = (hashCode*397) ^ InterestRate.GetHashCode();
                hashCode = (hashCode*397) ^ MonthlyRepayment.GetHashCode();
                hashCode = (hashCode*397) ^ TotalRepayment.GetHashCode();
                return hashCode;
            }
        }


    }
}
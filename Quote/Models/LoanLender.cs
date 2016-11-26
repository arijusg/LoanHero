namespace Quote.Models
{
    public class LoanLender
    {
        public LoanLender(Lender lender, int amountLent)
        {
            Lender = lender;
            AmountLent = amountLent;
        }

        public Lender Lender { get; }
        public int AmountLent { get; }
    }
}

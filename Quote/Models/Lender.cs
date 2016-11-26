namespace Quote.Models
{
    public class Lender
    {
        public Lender(string name, decimal interestRate, int availableCash)
        {
            Name = name;
            InterestRate = interestRate;
            AvailableCash = availableCash;
        }

        public string Name { get; }
        public decimal InterestRate { get; }
        public int AvailableCash { get; }

        public override string ToString()
        {
            return $"Name: {Name} InterestRate: {InterestRate} AvailableCash: {AvailableCash}";
        }

        protected bool Equals(Lender other)
        {
            return string.Equals(Name, other.Name) && InterestRate == other.InterestRate && AvailableCash == other.AvailableCash;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Lender) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ InterestRate.GetHashCode();
                hashCode = (hashCode*397) ^ AvailableCash;
                return hashCode;
            }
        }
    }
}
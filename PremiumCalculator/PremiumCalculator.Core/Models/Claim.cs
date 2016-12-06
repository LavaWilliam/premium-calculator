namespace PremiumCalculator.Core.Models
{
    using System;

    public class Claim
    {
        public DateTime ClaimDate { get; set; } = DateTime.MinValue;

        public override string ToString()
        {
            return this.ClaimDate.ToString();
        }
    }
}

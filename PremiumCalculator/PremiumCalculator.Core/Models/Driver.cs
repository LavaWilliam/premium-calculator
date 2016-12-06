namespace PremiumCalculator.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Driver
    {
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        public string Name { get; set; } = null;

        public string Occupation { get; set; } = null;

        public IEnumerable<Claim> PreviousClaims { get; set; } = null;

        public override string ToString()
        {
            int claims = PreviousClaims?.Count() ?? 0;
            string result = $"{Name} ({Occupation}) {DateOfBirth.ToString("dd/MM/yyyy")}";

            if (claims > 0)
            {
                string plural = claims > 1 ? "s" : string.Empty;
                return $"{result} ({claims} previous claim{plural})";
            }

            return result;
        }
    }
}

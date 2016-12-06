namespace PremiumCalculator.Core.Models
{
    using System;
    using System.Collections.Generic;

    public class PolicyDetails
    {
        private DateTime startDate = DateTime.MinValue;

        public DeclineReason DeclineReason { get; set; } = DeclineReason.None;

        public IEnumerable<Driver> Drivers { get; set; } = null;

        public bool IsApproved
        {
            get { return this.DeclineReason == DeclineReason.None; }
        }

        public decimal Premium { get; set; } = decimal.Zero;

        public string ReasonDeclined { get; set; } = null;

        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value.Date; }
        }

        public void Reset(decimal initialPremium = decimal.Zero)
        {
            this.DeclineReason = DeclineReason.None;
            this.Premium = initialPremium;
            this.ReasonDeclined = null;
        }

        public void Update(PolicyValidationException exception)
        {
            this.DeclineReason = exception.DeclineReason;
            this.Premium = decimal.Zero;
            this.ReasonDeclined = exception.Message;
        }
    }
}

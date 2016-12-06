namespace PremiumCalculator.Core
{
    using System;
    using PremiumCalculator.Core.Models;

    public class PolicyValidationException : Exception
    {
        private DeclineReason declineReason = DeclineReason.NotSpecified;

        public PolicyValidationException()
            : base("Declined (reason not specified).")
        {
        }

        public PolicyValidationException(string message)
            : base(message)
        {
        }

        public PolicyValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public PolicyValidationException(DeclineReason declineReason)
            : base(declineReason.ReasonText())
        {
            this.declineReason = declineReason;
        }

        public PolicyValidationException(DeclineReason declineReason, Exception innerException)
            : base(declineReason.ReasonText(), innerException)
        {
            this.declineReason = declineReason;
        }

        public PolicyValidationException(DeclineReason declineReason, params object[] args)
            : base(string.Format(declineReason.ReasonText(), args))
        {
            this.declineReason = declineReason;
        }

        public DeclineReason DeclineReason
        {
            get { return this.declineReason; }
        }
    }
}

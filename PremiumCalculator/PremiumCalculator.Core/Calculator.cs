namespace PremiumCalculator.Core
{
    using System;
    using PremiumCalculator.Core.Models;

    public class Calculator
    {
        private static int maxClaimsPerDriver = 5;
        private static int maxDrivers = 5;
        private static int minDrivers = 1;

        private decimal startingPoint = decimal.Zero;

        public Calculator()
        {
        }

        public delegate void PolicyValidationEventHandler(PolicyDetails details);

        public event PolicyValidationEventHandler Validate = null;

        public static int MaxClaimsPerDriver
        {
            get { return Calculator.maxClaimsPerDriver; }
            set { Calculator.maxClaimsPerDriver = value; }
        }

        public static int MaxDrivers
        {
            get { return Calculator.maxDrivers; }
            set { Calculator.maxDrivers = value; }
        }

        public static int MinDrivers
        {
            get { return Calculator.minDrivers; }
            set { Calculator.minDrivers = value; }
        }

        public decimal StartingPoint
        {
            get { return this.startingPoint; }
            set { this.startingPoint = value; }
        }

        public void CalculatePremium(PolicyDetails policyDetails)
        {
            if (policyDetails == null)
            {
                throw new ArgumentNullException(nameof(policyDetails));
            }

            try
            {
                policyDetails.Reset(this.StartingPoint);

                this.Validate?.Invoke(policyDetails);
            }
            catch (PolicyValidationException exception)
            {
                policyDetails.Update(exception);
            }
        }
    }
}

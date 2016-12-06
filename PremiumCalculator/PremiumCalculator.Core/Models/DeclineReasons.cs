namespace PremiumCalculator.Core.Models
{
    using System;
    using System.Collections.Generic;

    public enum DeclineReason
    {
        NotSpecified = -1,
        None = 0,
        NoDriversSpecified,
        InsufficientDriversSpecified,
        TooManyDriversSpecified,
        TooManyPreviousClaims,
        StartDateOfPolicy,
        AgeOfYoungestDriver,
        AgeOfOldestDriver,
        DriverHasTooManyClaims,
        PolicyHasTooManyClaims,
    }

    public static class DeclineReasonTexts
    {
        private static readonly Dictionary<DeclineReason, string> texts = new Dictionary<DeclineReason, string>()
        {
            { DeclineReason.None, null },
            { DeclineReason.NoDriversSpecified, "There are no drivers specified." },
            { DeclineReason.InsufficientDriversSpecified, "There is an insufficient number of drivers specified." },
            { DeclineReason.TooManyDriversSpecified, "There are too many drivers specified." },
            { DeclineReason.TooManyPreviousClaims, "One or more drivers has too many claims." },
            { DeclineReason.StartDateOfPolicy, "Start Date of Policy." },
            { DeclineReason.AgeOfYoungestDriver, "Age of Youngest Driver: {0}." },
            { DeclineReason.AgeOfOldestDriver, "Age of Oldest Driver: {0}." },
            { DeclineReason.DriverHasTooManyClaims, "Driver has more than {1} claims: {0}." },
            { DeclineReason.PolicyHasTooManyClaims, "Policy has more than {0} claims." },
        };

        public static string ReasonText(this DeclineReason reason)
        {
            string result = null;
            if (!DeclineReasonTexts.texts.TryGetValue(reason, out result))
            {
                result = string.Concat(reason.ToString(), "!");
                DeclineReasonTexts.texts[reason] = result;
            }

            return result;
        }
    }
}





namespace PremiumCalculator.Core.Validators
{
    using System;
    using System.Linq;
    using PremiumCalculator.Core.Models;

    public static class Validators
    {
        public static void DriverIsAccountant(PolicyDetails details)
        {
            if (details.Drivers
                .FirstOrDefault(x => x.Occupation.Equals("Accountant", StringComparison.InvariantCultureIgnoreCase)) != null)
            {
                details.Premium -= details.Premium / 10M;
            }
        }

        public static void DriverIsChauffeur(PolicyDetails details)
        {
            if (details.Drivers
                .FirstOrDefault(x => x.Occupation.Equals("Chauffeur", StringComparison.InvariantCultureIgnoreCase)) != null)
            {
                details.Premium += details.Premium / 10M;
            }
        }

        public static void ValidateAgeOldestDriver(PolicyDetails details)
        {
            var oldestDriver = details.Drivers.OrderBy(x => x.DateOfBirth).First();
            var age = oldestDriver.DateOfBirth.GetAgeInYears(details.StartDate);

            if (age >= 75)
            {
                throw new PolicyValidationException(DeclineReason.AgeOfOldestDriver, oldestDriver.Name);
            }
        }

        public static void ValidateAgeYoungestDriver(PolicyDetails details)
        {
            var youngestDriver = details.Drivers.OrderByDescending(x => x.DateOfBirth).First();
            var age = youngestDriver.DateOfBirth.GetAgeInYears(details.StartDate);

            if (age < 21)
            {
                throw new PolicyValidationException(DeclineReason.AgeOfYoungestDriver, youngestDriver.Name);
            }

            if (age >= 21 && age <= 25)
            {
                details.Premium += details.Premium / 5M;
            }
            else if (age > 25 && age < 75)
            {
                details.Premium -= details.Premium / 10M;
            }
        }

        public static void ValidateDriverClaimCount(PolicyDetails details)
        {
            int drivers = details.Drivers?.Count() ?? 0;

            if (drivers == 0)
            {
                throw new PolicyValidationException(DeclineReason.NoDriversSpecified);
            }

            if (drivers < Calculator.MinDrivers)
            {
                throw new PolicyValidationException(DeclineReason.InsufficientDriversSpecified);
            }

            if (drivers > Calculator.MaxDrivers)
            {
                throw new PolicyValidationException(DeclineReason.TooManyDriversSpecified);
            }

            int maxClaims = 0;
            maxClaims = details.Drivers
                .Select(x => Math.Max(maxClaims, x.PreviousClaims?.Count() ?? 0))
                .Max();

            if (maxClaims > Calculator.MaxClaimsPerDriver)
            {
                throw new PolicyValidationException(DeclineReason.TooManyPreviousClaims);
            }
        }

        public static void ValidatePreviousClaims(PolicyDetails details)
        {
            const int MaxDriverClaims = 2;
            const int MaxTotalClaims = 3;

            int totalNumberOfClaims = 0;

            foreach (var driver in details.Drivers.Where(x => x.PreviousClaims != null))
            {
                int driverClaims = 0;

                foreach (var claim in driver.PreviousClaims)
                {
                    ++driverClaims;
                    ++totalNumberOfClaims;

                    if (driverClaims > MaxDriverClaims)
                    {
                        throw new PolicyValidationException(DeclineReason.DriverHasTooManyClaims, driver.Name, MaxDriverClaims);
                    }

                    if (totalNumberOfClaims > MaxTotalClaims)
                    {
                        throw new PolicyValidationException(DeclineReason.PolicyHasTooManyClaims, MaxTotalClaims);
                    }

                    var age = claim.ClaimDate.GetAgeInYears(details.StartDate);

                    if (age < 1)
                    {
                        details.Premium += details.Premium / 5M;
                    }
                    else if (age < 5)
                    {
                        details.Premium += details.Premium / 10M;
                    }
                }
            }
        }

        public static void ValidateStartDate(PolicyDetails details)
        {
            if (details.StartDate < DateTime.Now.Date)
            {
                throw new PolicyValidationException(DeclineReason.StartDateOfPolicy);
            }
        }
    }
}

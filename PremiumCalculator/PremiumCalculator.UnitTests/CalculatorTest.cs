namespace PremiumCalculator.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PremiumCalculator.Core;
    using PremiumCalculator.Core.Models;
    using PremiumCalculator.Core.Validators;

    [TestClass]
    public class CalculatorTest
    {
        private Calculator premiumCalculator = null;

        [TestInitialize]
        public void Initialize()
        {
            this.premiumCalculator = new Calculator()
            {
                StartingPoint = 500M,
            };

            Calculator.MinDrivers = 1;
            Calculator.MaxDrivers = 5;
            Calculator.MaxClaimsPerDriver = 5;
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.premiumCalculator = null;
        }

        [TestMethod]
        public void TestInvalidEntries()
        {
            // Empty policy (no drivers, also then less than minimum 1).
            var policyDetails = new PolicyDetails()
            {
                StartDate = DateTime.Now.AddDays(1).Date,
            };

            this.premiumCalculator.Validate += Validators.ValidateDriverClaimCount;

            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.NoDriversSpecified, policyDetails.DeclineReason);

            // Create drivers, adding one too many.
            List<Driver> drivers = new List<Driver>();
            for (int i = 1; i <= Calculator.MaxDrivers + 1; i++)
            {
                drivers.Add(new Driver()
                {
                    Name = $"Driver {i}",
                    Occupation = $"Job {i}",
                    DateOfBirth = new DateTime(1970 + i - 1, i % 12, i % 28)
                });
            }

            policyDetails.Drivers = drivers;

            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.TooManyDriversSpecified, policyDetails.DeclineReason);

            // Remove drivers so that there is no more than the max allowed.
            policyDetails.Drivers = policyDetails.Drivers.Take(Calculator.MaxDrivers);

            // Add claims to each driver, increasing the number each time so that at least one driver has too many.
            foreach (var driver in policyDetails.Drivers)
            {
                int i = driver.DateOfBirth.Year - 1968;

                List<Claim> claims = new List<Claim>();

                do
                {
                    claims.Add(new Claim() { ClaimDate = new DateTime(1980, 1, i) });
                }
                while (--i > 0);

                driver.PreviousClaims = claims;
            }

            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.TooManyPreviousClaims, policyDetails.DeclineReason);

            // Remove excessive claims.
            foreach (var driver in policyDetails.Drivers
                .Where(x => (x.PreviousClaims?.Count() ?? 0) > Calculator.MaxClaimsPerDriver))
            {
                driver.PreviousClaims = driver.PreviousClaims.Take(Calculator.MaxClaimsPerDriver);
            }

            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.None, policyDetails.DeclineReason);
        }

        [TestMethod]
        public void TestRuleValidation_Occupation()
        {
            var policyDetails = new PolicyDetails()
            {
                StartDate = DateTime.Now.AddDays(1).Date,
                Drivers = new Driver[]
                {
                    new Driver()
                    {
                        Name = "William Orr",
                        Occupation = "Developer",
                        DateOfBirth = new DateTime(1962, 6, 21),
                        PreviousClaims = new Claim[]
                        {
                            new Claim() { ClaimDate = new DateTime(1980, 1, 1) }
                        }
                    }
                }
            };

            this.premiumCalculator.Validate += Validators.ValidateDriverClaimCount;
            this.premiumCalculator.Validate += Validators.DriverIsChauffeur;
            this.premiumCalculator.Validate += Validators.DriverIsAccountant;

            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.None, policyDetails.DeclineReason);

            Assert.AreEqual(this.premiumCalculator.StartingPoint, policyDetails.Premium);

            // Change occupation to "Chauffeur".
            policyDetails.Drivers.First().Occupation = "Chauffeur";

            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.None, policyDetails.DeclineReason);

            Assert.AreEqual(this.premiumCalculator.StartingPoint * 1.1M, policyDetails.Premium);

            // Change occupation to "Accountant".
            policyDetails.Drivers.First().Occupation = "Accountant";

            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.None, policyDetails.DeclineReason);

            Assert.AreEqual(this.premiumCalculator.StartingPoint * 0.9M, policyDetails.Premium);
        }

        [TestMethod]
        public void TestRuleValidation_Age()
        {
            // Setup policy details with a driver who is 21.
            var policyDetails = new PolicyDetails()
            {
                StartDate = DateTime.Now.AddDays(1).Date,
                Drivers = new Driver[]
                {
                    new Driver()
                    {
                        Name = "William Orr",
                        Occupation = "Developer",
                        DateOfBirth = new DateTime(1962, 6, 21),
                    },

                    new Driver()
                    {
                        Name = "William Young",
                        Occupation = "Youth",
                        DateOfBirth = DateTime.Now.AddYears(-21).Date,
                    }
                }
            };

            this.premiumCalculator.Validate += Validators.ValidateDriverClaimCount;
            this.premiumCalculator.Validate += Validators.ValidateAgeYoungestDriver;
            this.premiumCalculator.Validate += Validators.ValidateAgeOldestDriver;

            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.None, policyDetails.DeclineReason);

            Assert.AreEqual(this.premiumCalculator.StartingPoint * 1.2M, policyDetails.Premium);

            // Change the second driver to be 26
            policyDetails.Drivers.Skip(1).First().DateOfBirth = DateTime.Now.AddYears(-26).Date;
            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.None, policyDetails.DeclineReason);

            Assert.AreEqual(this.premiumCalculator.StartingPoint * 0.9M, policyDetails.Premium);

            // Change the second driver to be 76
            policyDetails.Drivers.Skip(1).First().DateOfBirth = DateTime.Now.AddYears(-76).Date;
            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.AgeOfOldestDriver, policyDetails.DeclineReason);

            // Change the second driver to be 20
            policyDetails.Drivers.Skip(1).First().DateOfBirth = DateTime.Now.AddYears(-20).Date;
            this.premiumCalculator.CalculatePremium(policyDetails);

            Assert.AreEqual(DeclineReason.AgeOfYoungestDriver, policyDetails.DeclineReason);
        }
    }
}

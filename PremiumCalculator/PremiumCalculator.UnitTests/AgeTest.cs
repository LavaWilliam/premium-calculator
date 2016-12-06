namespace PremiumCalculator.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PremiumCalculator.Core;

    [TestClass]
    public class AgeTest
    {
        [TestMethod]
        public void TestAgeCalculation()
        {
            int year = 1962;
            int ryear = 2016;
            int month = 6;
            int day = 21;
            int age = 0;
            int expectedAge = 54;

            DateTime reference = DateTime.MinValue;
            DateTime dt = new DateTime(year, month, day);

            Console.WriteLine($"Date = {dt.ToString("dd-MM-yyyy")}");

            for (int y = 0; y >= -1; --y)
            {
                Console.WriteLine();

                for (int i = -1; i < 2; ++i)
                {
                    reference = new DateTime(ryear + y, month, day + i);
                    age = dt.GetAgeInYears(reference);

                    Console.WriteLine($"On {reference.ToString("dd-MM-yyyy")}, age = {age}");

                    if (i < 1)
                    {
                        Assert.AreEqual(expectedAge + y + i, age);
                    }
                    else
                    {
                        Assert.AreEqual(expectedAge + y, age);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Currently ({DateTime.Now.ToString("dd-MM-yyyy")}) age = {dt.GetAgeInYears()}");
        }
    }
}

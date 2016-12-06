namespace PremiumCalculator.Core
{
    using System;

    public static class DateTimeExtensions
    {
        public static int GetAgeInYears(this DateTime date, DateTime referenceDate)
        {
            int age = referenceDate.Year - date.Year;
            if (referenceDate < date.AddYears(age)) --age;
            return age;
        }

        public static int GetAgeInYears(this DateTime date)
        {
            return DateTimeExtensions.GetAgeInYears(date, DateTime.Now.Date);
        }
    }
}

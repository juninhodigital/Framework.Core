using System;
using System.Collections.Generic;
using System.Globalization;

namespace Framework.Core
{
    /// <summary>
    /// Contains DateTime Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        ///  Converts the DateTime to string
        /// </summary>
        /// <param name="DateTime">DateTime</param>
        /// <param name="UseDefaultFormat">Indicates whether the string must be formatted according to the Brazilian format</param>
        /// <returns>string</returns>
        public static string ToString(this DateTime @DateTime, bool UseDefaultFormat)
        {
            if (UseDefaultFormat)
            {
                return @DateTime.ToString(Constants.PTBR_DATETIME);
            }
            else
            {
                return @DateTime.ToString();
            }
        }

        /// <summary>
        /// Determines whether [is leap year] [the specified date].
        /// </summary>
        /// <param name="DateTime">The date.</param>
        /// <returns>
        /// 	<c>true</c> if [is leap year] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLeapYear(this DateTime @DateTime)
        {
            return @DateTime.Year % 4 == 0 && (@DateTime.Year % 100 != 0 || @DateTime.Year % 400 == 0);
        }

        /// <summary>
        /// Determines whether the specified date is a weekend.
        /// </summary>
        /// <param name="DateTime">Source date</param>
        /// <returns>
        /// 	<c>true</c> if the specified source is a weekend; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekend(this DateTime @DateTime)
        {
            return @DateTime.DayOfWeek == DayOfWeek.Saturday || @DateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        ///     A DateTime extension method that query if '@this' is a week day.
        /// </summary>
        /// <param name="DateTime">The @this to act on.</param>
        /// <returns>true if '@this' is a week day, false if not.</returns>
        public static bool IsWeekDay(this DateTime @DateTime)
        {
            return !(@DateTime.DayOfWeek == DayOfWeek.Saturday || @DateTime.DayOfWeek == DayOfWeek.Sunday);
        }

        /// <summary>
        /// Determines if the date is some time in the future
        /// </summary>
        /// <param name="DateTime">Date to check</param>
        /// <returns>True if it is, false otherwise</returns>
        public static bool IsInFuture(this DateTime @DateTime)
        {
            return DateTime.Now < @DateTime;
        }

        /// <summary>
        /// Determines if the date is some time in the past
        /// </summary>
        /// <param name="DateTime">Date to check</param>
        /// <returns>True if it is, false otherwise</returns>
        public static bool IsInPast(this DateTime @DateTime)
        {
            return DateTime.Now > @DateTime;
        }

        /// <summary>
        ///     An extension method to determines whether the object is equal to any of the provided values.
        /// </summary>
        /// <param name="DateTime">The object to be compared.</param>
        /// <param name="values">The value list to compare with the object.</param>
        /// <returns>true if the values list contains the object, else false.</returns>        
        public static bool In(this DateTime @DateTime, params DateTime[] values)
        {
            return Array.IndexOf(values, @DateTime) != -1;
        }

        /// <summary>
        ///     An extension method to determines whether the object is equal to any of the provided values.
        /// </summary>
        /// <param name="DateTime">The object to be compared.</param>
        /// <param name="values">The value list to compare with the object.</param>
        /// <returns>true if the values list contains the object, else false.</returns>        
        public static bool NotIn(this DateTime @DateTime, params DateTime[] values)
        {
            return In(@DateTime, values);
        }

        /// <summary>
        /// Returns the First Day of the Month
        /// </summary>
        /// <param name="DateTime">DateTime</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime @DateTime)
        {
            return new DateTime(@DateTime.Year, @DateTime.Month, 1);
        }

        /// <summary>
        /// Returns the Last Day of the Month
        /// </summary>
        /// <param name="DateTime">DateTime</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime @DateTime)
        {
            return new DateTime(@DateTime.Year, @DateTime.Month, DateTime.DaysInMonth(@DateTime.Year, @DateTime.Month));
        }

        /// <summary>
        /// Check if the date is between two other days
        /// </summary>
        /// <param name="DateTime">DateTime</param>
        /// <param name="From">From</param>
        /// <param name="To">To</param>
        /// <param name="ConsiderHours">Indicates whether the time will be consider to calculate</param>
        /// <returns></returns>
        public static bool Between(this DateTime @DateTime, DateTime @From, DateTime @To, bool ConsiderHours = false)
        {
            if (ConsiderHours)
            {
                return (@DateTime >= @From && @DateTime <= @To);
            }
            else
            {
                var oDate = new DateTime(@DateTime.Year, @DateTime.Month, @DateTime.Day);

                var oFrom = new DateTime(@From.Year, @From.Month, @From.Day);
                var oTo   = new DateTime(@To.Year, @To.Month, @To.Day);

                return (oDate >= oFrom && oDate <= @To);
            }
        }

        /// <summary>
        ///     A DateTime extension method that query if '@this' is morning.
        /// </summary>
        /// <param name="DateTime">The @this to act on.</param>
        /// <returns>true if morning, false if not.</returns>
        public static bool IsMorning(this DateTime @DateTime)
        {
            return @DateTime.TimeOfDay < new DateTime(2000, 1, 1, 12, 0, 0).TimeOfDay;
        }

        /// <summary>
        ///     A DateTime extension method that ages the given this.
        /// </summary>
        /// <param name="DateTime">The @this to act on.</param>
        /// <returns>An int.</returns>
        public static int Age(this DateTime @DateTime)
        {
            if (DateTime.Today.Month < @DateTime.Month || DateTime.Today.Month == @DateTime.Month && DateTime.Today.Day < @DateTime.Day)
            {
                return DateTime.Today.Year - @DateTime.Year - 1;
            }

            return DateTime.Today.Year - @DateTime.Year;
        }

        /// <summary>
        ///     A DateTime extension method that elapsed the given datetime.
        /// </summary>
        /// <param name="DateTime">The datetime to act on.</param>
        /// <returns>A TimeSpan.</returns>
        public static TimeSpan Elapsed(this DateTime @DateTime)
        {
            return DateTime.Now - @DateTime;
        }

        /// <summary>
        ///     A DateTime extension method that query if 'time' is time equal.
        /// </summary>
        /// <param name="DateTime">The time to act on.</param>
        /// <param name="timeToCompare">Date/Time of the time to compare.</param>
        /// <returns>true if time equal, false if not.</returns>
        public static bool IsTimeEqual(this DateTime @DateTime, DateTime timeToCompare)
        {
            return (@DateTime.TimeOfDay == timeToCompare.TimeOfDay);
        }

        /// <summary>
        ///     A DateTime extension method that query if '@this' is today.
        /// </summary>
        /// <param name="DateTime">The @this to act on.</param>
        /// <returns>true if today, false if not.</returns>
        public static bool IsToday(this DateTime @DateTime)
        {
            return @DateTime.Date == DateTime.Today;
        }

        /// <summary>
        /// The ISO 8601 timestamp (preferable Zulu time) of the request set by the sender.
        /// </summary>
        /// <param name="DateTime"></param>
        /// <returns></returns>
        public static string ToZulu(this DateTime @DateTime)
        {
            return @DateTime.ToUniversalTime().ToString("o");
        }

        /// <summary>
        /// Returns the previous business day
        /// </summary>
        /// <param name="DateTime">The @this to act on.</param>
        /// <param name="holidays">holiday calendar list</param>
        /// <returns></returns>
        public static DateTime PreviousBusinessDay(this DateTime @DateTime, List<DateTime> holidays= null)
        {
            if (holidays.IsNull())
            {
                while (true)
                {
                    if (@DateTime.IsWeekend())
                    {
                        @DateTime = @DateTime.AddDays(-1);
                    }
                    else
                    {
                        break;
                    }
                }

                return @DateTime;
            }
            else
            {
                while (true)
                {
                    if (@DateTime.IsWeekend() || holidays.Exists(h => h.Equals(@DateTime)))
                    {
                        @DateTime = @DateTime.AddDays(-1);
                    }
                    else
                    {
                        break;
                    }
                }

                return @DateTime;

            }
        }

        #endregion
    }
}

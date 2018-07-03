using System;
using System.Globalization;

namespace Framework.Core
{
    /// <summary>
    /// Contains Double Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        ///  Converts the Double to string
        /// </summary>
        /// <param name="Double">Double</param>
        /// <param name="UseDefaultFormat">Indicates whether the string must be formatted according to the Brazilian format</param>
        /// <returns>string</returns>
        public static string ToString(this Double @Double, bool UseDefaultFormat)
        {
            if (UseDefaultFormat)
            {
                return @Double.ToString(Constants.PTBR_CURRENCY);
            }
            else
            {
                return @Double.ToString();
            }
        }

        /// <summary>
        ///  Converts the Double to string to the currency format of the ginve culture
        /// </summary>
        /// <param name="Double"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        ///     double valor = 154.20;
        ///     string texto_en = valor.ToString("en-US"); // $154.20
        ///     string texto_br = valor.ToString("pt-BR"); // R$ 154,20
        /// </code>
        /// </example>
        public static string ToString(this double @Double, string cultureName)
        {
            var oCultureInfo = new CultureInfo(cultureName);

            return string.Format(oCultureInfo, "{0:C}", @Double);
        }

        /// <summary>
        /// Truncates the decimal part of the given decimal number
        /// </summary>
        /// <param name="Double">The given decimal number</param>
        /// <returns>The truncated decimal number</returns>
        public static double Truncate(this double @Double)
        {
            return (long)Math.Truncate(@Double);
        }

        /// <summary>
        /// Rounds the decimal part of the given decimal number
        /// </summary>
        /// <param name="Double">The given decimal number</param>
        /// <returns>The rounded value</returns>
        public static double Round(this double @Double)
        {
            return (long)Math.Round(@Double);
        }

        /// <summary>
        ///     An extension method to determines whether the object is equal to any of the provided values.
        /// </summary>
        /// <param name="Double">The object to be compared.</param>
        /// <param name="values">The value list to compare with the object.</param>
        /// <returns>true if the values list contains the object, else false.</returns>        
        public static bool In(this double @Double, params double[] values)
        {
            return Array.IndexOf(values, @Double) != -1;
        }

        /// <summary>
        ///     An extension method to determines whether the object is not equal to any of the provided values.
        /// </summary>
        /// <param name="Double">The object to be compared.</param>
        /// <param name="values">The value list to compare with the object.</param>
        /// <returns>true if the values list contains the object, else false.</returns>        
        public static bool NotIn(this double @Double, params double[] values)
        {
            return !In(@Double, values);
        }

        /// <summary>
        ///     Returns a value that indicates whether the specified value is not a number ().
        /// </summary>
        /// <param name="Double">A double-precision floating-point number.</param>
        /// <returns>true if  evaluates to ; otherwise, false.</returns>
        public static Boolean IsNaN(this Double @Double)
        {
            return Double.IsNaN(@Double);
        }

        #endregion
    }
}

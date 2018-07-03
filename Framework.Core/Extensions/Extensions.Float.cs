using System;

namespace Framework.Core
{
    /// <summary>
    /// Contains Float Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        ///  Converts the float to string
        /// </summary>
        /// <param name="float">float</param>
        /// <param name="UseDefaultFormat">Indicates whether the string must be formatted according to the Brazilian format</param>
        /// <returns>string</returns>
        public static string ToString(this float @float, bool UseDefaultFormat)
        {
            if (UseDefaultFormat)
            {
                return @float.ToString(Constants.PTBR_CURRENCY);
            }
            else
            {
                return @float.ToString();
            }
        }

        #endregion
    }
}

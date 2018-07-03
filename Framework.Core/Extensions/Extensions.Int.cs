using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core
{
    /// <summary>
    /// Contains Int Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        /// Check if a specific value is in the param collection
        /// </summary>
        /// <param name="int">param type</param>
        /// <param name="values">param collection</param>
        /// <returns>bool</returns>
        public static bool In(this int @int, params int[] @values)
        {           
            if (@values.IsNull())
            {
                return false;
            }
            else
            {
               var Has = false;

                for (int i = 0; i < values.Length; i++)
                {
                    var item = values[i];

                    if (item == @int)
                    {
                        Has = true;
                        break;
                    }
                }

                return Has;
            }
        }

        /// <summary>
        /// Check if a specific value is not in the param collection
        /// </summary>
        /// <param name="int">param type</param>
        /// <param name="values">param collection</param>
        /// <returns>bool</returns>
        public static bool NotIn(this int @int, params int[] @values)
        {
            return !In(@int, values);
        }

        /// <summary>
        /// Check if the given number is between two number
        /// </summary>
        /// <param name="int">@int</param>
        /// <param name="lower">lower</param>
        /// <param name="upper">upper</param>
        /// <returns></returns>
        public static bool Between(this int @int, int lower, int upper)
        {
            return @int.CompareTo(lower) >= 0 && @int.CompareTo(upper) < 0;
        }

        /// <summary>
        /// Check if the integer value is Even
        /// </summary>
        /// <param name="int">integer value</param>
        /// <returns>bool</returns>
        public static bool IsEven(this int @int)
        {
            return ((@int % 2) == 0);
        }

        /// <summary>
        /// Check if the integer value is Odd
        /// </summary>
        /// <param name="int">integer value</param>
        /// <returns>bool</returns>
        public static bool IsOdd(this int @int)
        {
            return ((@int % 2) != 0);
        }

        #endregion
    }
}

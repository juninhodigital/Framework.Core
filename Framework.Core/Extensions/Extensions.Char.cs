using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Framework.Core
{
    /// <summary>
    /// Contains Char Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        ///     A char extension method that repeats a character the specified number of times.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="repeatCount">Number of repeats.</param>
        /// <returns>The repeated char.</returns>
        public static string Repeat(this char @this, int repeatCount)
        {
            return new string(@this, repeatCount);
        }

        #endregion
    }
}

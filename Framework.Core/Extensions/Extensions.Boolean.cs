using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core
{
    /// <summary>
    /// Providers Extension Methods that are a special kind of static method, 
    /// but they are called as if they were instance methods on the extended type. 
    /// </summary>
	public static partial class Extensions
	{
        #region| Methods |

        /// <summary>
        ///     A bool extension method that convert this object into a binary representation.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A binary represenation of this object.</returns>
        public static byte ToBinary(this bool @this)
        {
            return Convert.ToByte(@this);
        }

        /// <summary>
        ///  A bool extension method that execute an Action if the value is true.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="action">The action to execute.</param>
        public static bool IfTrue(this bool @this, Action action)
        {
            if (@this)
            {
                action();
            }
            return @this;
        }

        /// <summary>
        ///     A bool extension method that execute an Action if the value is false.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="action">The action to execute.</param>    
        public static bool IfFalse(this bool @this, Action action)
        {
            if (!@this)
            {
                action();
            }
            return @this;
        } 

        #endregion
	}
}

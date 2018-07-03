using System;

namespace Framework.Core
{
    /// <summary>
    /// Contains Array Extension Methods 
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        /// Check if the string array is null or contains no elements
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static bool IsNull(this string[] @object)
        {
            return @object == null || @object.Length == 0;
        }
        
        /// <summary>
        /// Check if the string array is not null and contains elements
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static bool IsNotNull(this string[] @object)
        {
            return !@object.IsNull();
        }

        /// <summary>
        /// An Array extension method that clears the array.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        public static void ClearAll(this Array @this)
        {
            Array.Clear(@this, 0, @this.Length);
        }

        #endregion
    }  
}

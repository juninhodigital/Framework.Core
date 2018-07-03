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
        ///  Writes the specified string value, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="object">Source</param>
        /// <param name="Message">The value to write</param>
        public static void Print(this object @object, string Message)
        {
            System.Console.WriteLine(Message);
        }

        #endregion
	}
}

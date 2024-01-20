using System.Diagnostics;

namespace Framework.Core
{
    /// <summary>
    /// Contains Exception Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        /// Get the detailed information of the Exception including FileName, Method and Line Number.
        /// </summary>
        /// <param name="oException">Exception</param>
        /// <returns>Details exception information</returns>
        public static string GetDetails(this Exception oException)
        {
            var output = string.Empty;
            var oStackTrace = new StackTrace(oException, true);

            // Get the top stack frame
            var oStackFrame = oStackTrace.GetFrame(0);

            if(oStackFrame != null ) 
            {
                output = string.Format("{0}:{1}({2})", oStackFrame.GetFileName(), oStackFrame.GetMethod()?.Name, oStackFrame.GetFileLineNumber());

                oStackFrame = null;
            }
            
            oStackTrace = null;

            return output;
        }

        #endregion
    }  
}

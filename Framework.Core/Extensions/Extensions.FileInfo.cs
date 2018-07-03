using System.Diagnostics;
using System.IO;

namespace Framework.Core
{
    /// <summary>
    /// Contains FileInfo Extension Methods
    /// </summary>
    public static partial class Extensions
	{
        #region| Methods |

        /// <summary>
        /// Open with default 'open' program
        /// </summary>
        /// <param name="value"></param>
        public static void Open(this FileInfo value)
        {
            if (!value.Exists)
            {
                throw new FileNotFoundException("Framework: O arquivo não existe");
            }

            var oProcess = new Process();

            oProcess.StartInfo.FileName = value.FullName;
            oProcess.StartInfo.Verb = "Open";
            oProcess.Start();

            oProcess.Dispose();
        }

        /// <summary>
        /// Print the file
        /// </summary>
        /// <param name="value"></param>
        public static void Print(this FileInfo value)
        {
            if (!value.Exists)
            {
                throw new FileNotFoundException("Framework: O arquivo não existe");
            }

            var oProcess = new Process();

            oProcess.StartInfo.FileName = value.FullName;
            oProcess.StartInfo.Verb = "Print";
            oProcess.Start();

            oProcess.Dispose();
        }

        #endregion
	}
}

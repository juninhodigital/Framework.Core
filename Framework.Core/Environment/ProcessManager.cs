using System.Diagnostics;
using System.Threading;

namespace Framework.Core
{
    /// <summary>
    /// Class that helps with managing processes
    /// </summary>
    public sealed class ProcessManager
    {
        #region| Methods |

        /// <summary>
        /// Kills a process
        /// </summary>
        /// <param name="ProcessName">Name of the process without the ending (ie iexplore instead of iexplore.exe)</param>
        public static void KillProcess(string ProcessName)
        {
            var oProcesses = Process.GetProcessesByName(ProcessName);

            for (int i = 0; i < oProcesses.Length; i++)
            {
                oProcesses[i].Kill();
            }
        }

        /// <summary>
        /// Kills a process after a specified amount of time
        /// </summary>
        /// <param name="ProcessName">Name of the process</param>
        /// <param name="TimeToKill">Amount of time (in ms) until the process is killed.</param>
        public static void KillProcess(string ProcessName, int TimeToKill)
        {
            ThreadPool.QueueUserWorkItem(delegate { KillProcessAsync(ProcessName, TimeToKill); });
        }
      
        /// <summary>
        /// Kills a process asyncronously
        /// </summary>
        /// <param name="ProcessName">Name of the process to kill</param>
        /// <param name="TimeToKill">Amount of time until the process is killed</param>
        private static void KillProcessAsync(string ProcessName, int TimeToKill)
        {
            if (TimeToKill > 0)
            {
                Thread.Sleep(TimeToKill);
            }

            KillProcess(ProcessName);
        }

        #endregion
    }
}

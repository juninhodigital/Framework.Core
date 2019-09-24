using System;
using System.Diagnostics;

namespace Framework.Core
{
    /// <summary>
    /// This class is in charge of getting some time execution basedon the MiniProfiler from ASP.NET Core
    /// https://app.pluralsight.com/library/courses/using-miniprofiler-aspdotnet-core
    /// </summary>
    public class MiniProfiler : IDisposable
    {
        #region| Properties |

        public Stopwatch Watch { get; private set; }
        private readonly string Name;

        #endregion

        #region| Constructor |

        /// <summary>
        ///  Returns the execution time code between its creation and its disposal
        /// </summary>
        /// <param name="name">A descriptive name for the code that is encapsulated by the resulting Timing's lifetime.</param>
        public MiniProfiler(string name)
        {
            this.Watch = Stopwatch.StartNew();
            this.Name = name;
        }

        #endregion

        #region| Methods 

        /// <summary>
        ///  Gets the total elapsed time measured by the current instance
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetElapsedTime()
        {
            return Watch.Elapsed;
        }

        /// <summary>
        /// Gets the value of the current System.TimeSpan structure expressed in whole and fractional milliseconds.
        /// </summary>
        /// <param name="formatOutput">Indicates whether the output should be formatted</param>
        /// <returns>Gets the value of the current System.TimeSpan structure expressed in whole and fractional milliseconds</returns>
        public string GetExecutionTime(bool formatOutput = true)
        {
            if (formatOutput)
            {
                return $"Profile: {this.Name}, execution time: {Watch.Elapsed.TotalMilliseconds}ms";
            }
            else
            {
                return $"{Watch.Elapsed.TotalMilliseconds}ms";
            }
        }

        #endregion

        #region| IDisposable |

        public void Dispose()
        {
            // the code that you want to measure comes here
            Watch.Stop();

            var elapsedMs = Watch.ElapsedMilliseconds;

            Debug.WriteLine($"Profile: {this.Name}, execution time: {Watch.Elapsed.TotalMilliseconds}ms");
        } 

        #endregion
    }
}

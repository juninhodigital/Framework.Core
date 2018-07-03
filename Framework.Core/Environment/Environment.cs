using System;

namespace Framework.Core
{
    /// <summary>
    /// Class designed to give information about the current system
    /// </summary>
    public sealed class SO
    {
        #region| Properties |

        /// <summary>
        /// Name of the machine running the app
        /// </summary>
        public static string MachineName
        {
            get { return System.Environment.MachineName; }
        }

        /// <summary>
        /// Gets the user name that the app is running under
        /// </summary>
        public static string UserName
        {
            get { return System.Environment.UserName; }
        }

        /// <summary>
        /// Name of the domain that the app is running under
        /// </summary>
        public static string DomainName
        {
            get { return System.Environment.UserDomainName; }
        }

        /// <summary>
        /// Name of the OS running
        /// </summary>
        public static string OSName
        {
            get { return System.Environment.OSVersion.Platform.ToString(); }
        }

        /// <summary>
        /// Version information about the OS running
        /// </summary>
        public static string OSVersion
        {
            get { return System.Environment.OSVersion.Version.ToString(); }
        }

        /// <summary>
        /// The service pack running on the OS
        /// </summary>
        public static string OSServicePack
        {
            get { return System.Environment.OSVersion.ServicePack; }
        }

        /// <summary>
        /// Full name, includes service pack, version, etc.
        /// </summary>
        public static string OSFullName
        {
            get { return System.Environment.OSVersion.VersionString; }
        }

        /// <summary>
        /// Gets the current stack trace information
        /// </summary>
        public static string StackTrace
        {
            get { return System.Environment.StackTrace; }
        }

        /// <summary>
        /// Returns the number of processors on the machine
        /// </summary>
        public static int NumberOfProcessors
        {
            get { return System.Environment.ProcessorCount; }
        }

        /// <summary>
        /// The total amount of memory the GC believes is used
        /// by the app in bytes
        /// </summary>
        public static long TotalMemoryUsed
        {
            get { return GC.GetTotalMemory(false); }
        }

        #endregion
    }
}

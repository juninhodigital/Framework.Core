using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
        /// Gets the drive information for a directory
        /// </summary>
        /// <param name="Directory">The directory to get the drive info of</param>
        /// <returns>The drive info connected to the directory</returns>
        public static DriveInfo DriveInfo(this DirectoryInfo Directory)
        {
            return new DriveInfo(Directory.Root.FullName);
        }
        
        #endregion
	}
}

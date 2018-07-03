using System;
using System.Net.NetworkInformation;

namespace Framework.Core
{
    /// <summary>
    /// Contains Uri Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        ///  Attempts to send an Internet Control Message Protocol (ICMP) echo message
        ///  to the specified computer, and receive a corresponding ICMP echo reply message
        ///  from that computer. This method allows you to specify a time-out value for the operation.
        /// </summary>
        /// <param name="uri">A System.String that identifies the computer that is the destination for the ICMP echo message. 
        /// The value specified for this parameter can be a host name or a string representation of an IP address.</param>
        /// <returns>
        /// A System.Net.NetworkInformation.PingReply object that provides information
        /// about the ICMP echo reply message if one was received, or provides the reason
        /// for the failure if no message was received.
        /// </returns>
        public static IPStatus Ping(this Uri uri)
        {
            return uri.Ping(3000);
        }

        /// <summary>
        ///  Attempts to send an Internet Control Message Protocol (ICMP) echo message
        ///  to the specified computer, and receive a corresponding ICMP echo reply message
        ///  from that computer. This method allows you to specify a time-out value for the operation.
        /// </summary>
        /// <param name="uri">A System.String that identifies the computer that is the destination for the ICMP echo message. 
        /// The value specified for this parameter can be a host name or a string representation of an IP address.</param>
        /// <param name="timeout"> An System.Int32 value that specifies the maximum number of milliseconds (after sending the echo message) to wait for the ICMP echo reply message.</param>
        /// <returns>
        /// A System.Net.NetworkInformation.PingReply object that provides information
        /// about the ICMP echo reply message if one was received, or provides the reason
        /// for the failure if no message was received.
        /// </returns>
        public static IPStatus Ping(this Uri uri, int timeout)
        {
            return new Ping().Send(uri.Host, timeout).Status;
        } 
        
        #endregion
    }
}

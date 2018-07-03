using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

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
        /// Attempts to send an Internet Control Message Protocol (ICMP) echo message
        ///  to the specified computer, and receive a corresponding ICMP echo reply message from that computer.
        /// </summary>
        /// <param name="hostNameOrAddress">
        /// A String that identifies the computer that is the destination for
        ///  the ICMP echo message. The value specified for this parameter can be a host
        ///  name or a string representation of an IP address.</param>
        /// <returns>true if the System.Net.NetworkInformation.PingReply == PingReply.Sucess</returns>
        public static bool Ping(string hostNameOrAddress)
        {
            try
            {
                var oPing = new System.Net.NetworkInformation.Ping();

                var oReply = oPing.Send(hostNameOrAddress);

                if (oReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception oException)
            {
                System.Diagnostics.Debug.WriteLine(oException.Message);
                return false;
            }
        }

        static void RouteAdd(string DestinoIP, string GatewayIP)
        {
            try
            {
                var oProcess = new Process();

                oProcess.StartInfo.UseShellExecute = false;

                oProcess.StartInfo.FileName  = "route";
                oProcess.StartInfo.Arguments = "-p add " + DestinoIP + " mask 255.255.0.0 " + GatewayIP;
                oProcess.StartInfo.RedirectStandardOutput = true;
                oProcess.StartInfo.StandardOutputEncoding = Encoding.ASCII;

                oProcess.Start();

            }
            catch (Exception oException)
            {
                System.Diagnostics.Debug.WriteLine(oException.Message);
            }
        }
        
        #endregion
	}
}

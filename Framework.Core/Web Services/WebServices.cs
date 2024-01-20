using System.Net;

namespace Framework.Core
{
    /// <summary>
    /// Contains useful methods to user XML Web Services
    /// </summary>
    public sealed class WebService
    {
        #region| Methods |

        /// <summary>
        /// Returns an instance of the System.Net.WebProxy class with the specified parameters
        /// </summary>
        /// <param name="ProxyName">Proxy Name or IP</param>
        /// <param name="ProxyPort">Proxy Port Number</param>
        /// <param name="oCredential">NetworkCredential</param>
        /// <param name="UseSystemProxy">Indicates whether the method will return a proxy configured with the Internet Explorer settings of the currently</param>
        /// <returns>WebProxy</returns>
        private WebProxy? GetProxy(string ProxyName, string ProxyPort, NetworkCredential? oCredential = null, bool UseSystemProxy = true)
        {
            WebProxy? oProxy = null;

            try
            {
                if (UseSystemProxy)
                {
                    oProxy = WebRequest.GetSystemWebProxy() as WebProxy;
                }
                else
                {
                    // Create new Proxy passing the ProxyName and ProxyPort (Example: MYISASERVER:8080
                    oProxy = new WebProxy(string.Format("{0}:{1}", ProxyName, ProxyPort));
                }

                if (oProxy!=null)
                {
                    if (oCredential==null)
                    {
                        oProxy.Credentials = CredentialCache.DefaultCredentials;
                    }
                    else
                    {
                        // Set the Credentials to the Proxy Client
                        oProxy.UseDefaultCredentials = false;
                        oProxy.Credentials = oCredential;
                    }

                    oProxy.UseDefaultCredentials = false;
                    oProxy.Credentials = oCredential;

                    return oProxy;
                }
            }
            catch (Exception)
            {
            }

            return oProxy;
        }

        #endregion
    }
}
